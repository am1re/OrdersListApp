import httpClient from '@/services/http-client'

const insertProductDataIntoOrderItem = function (orderItem, rootGetters) {
    let product = rootGetters['products/getById'](orderItem.productId);

    orderItem.photoUrl = product.photoUrl;
    orderItem.name = product.name;

    return orderItem;
}

const insertProductDataIntoOrder = async function (data, dispatch, rootGetters) {
    const process = function (order, rootGetters) {
        order.status = order.status.name
        order.total = 0
        order.orderItems.forEach(orderItem => {
            order.total += orderItem.productPrice * orderItem.quantity

            insertProductDataIntoOrderItem(orderItem, rootGetters)
        })
    }

    await dispatch("products/fetchAll", null, { root: true })

    if (Array.isArray(data))
        data.forEach(order => process(order, rootGetters))
    else process(data, rootGetters)

    return data
}

export default {
    namespaced: true,
    state: {
        orders: [],
    },
    getters: {
        getAll(state) {
            return state.orders;
        },
        getById: state => id => {
            return state.orders.find(x => x.id === id);
        },
    },
    actions: {
        async fetchAll({ commit, dispatch, rootGetters }) {
            try {
                const response = await httpClient.get('/orders?limit=100');
                const data = await insertProductDataIntoOrder(response.data.data, dispatch, rootGetters)

                commit('setItems', data)
            }
            catch (err) {
                throw new Error("Failed to fetch orders from API!");
            }
        },
        async updateItem({ dispatch, commit, rootGetters }, payload) {
            try {
                const updOrderItems = payload.orderItems.map(async e => {
                    await httpClient.put(`/orders/${payload.id}/items`, e)
                })
                await Promise.all(updOrderItems);
                const response = await httpClient.put(`/orders/${payload.id}`, payload)

                const data = await insertProductDataIntoOrder(response.data.data, dispatch, rootGetters)
                commit('updateItem', data);
            }
            catch (err) {
                throw new Error("Failed to update order!");
            }
        },
        async deleteItem({ commit }, payload) {
            try {
                const response = await httpClient.delete(`/orders/${payload.id}`, payload)
                if (response.status == 204)
                    commit('removeItem', payload.id);
            }
            catch (err) {
                throw new Error("Failed to delete order!");
            }

        },
        async deleteOrderItem({ commit }, payload) {
            try {
                const response = await httpClient.delete(`/orders/${payload.orderId}/items`, { data: payload })
                if (response.status == 204)
                    commit('removeOrderItem', payload.orderId, payload.productId);
            }
            catch (err) {
                throw new Error("Failed to delete order item!");
            }
        },
        async addItem({ dispatch, commit, rootGetters }, payload) {
            try {
                const response = await httpClient.post('/orders', payload)
                const data = await insertProductDataIntoOrder(response.data.data, dispatch, rootGetters)
                commit('addItem', data);
            }
            catch (err) {
                throw new Error("Failed to add order!");
            }
        },
        async addOrderItem({ dispatch, commit, rootGetters, getters }, payload) { // TODO: i'm sorry for that
            try {
                await dispatch("products/fetchAll", null, { root: true })

                const response = await httpClient.post(`/orders/${payload.orderId}/items`, payload)
                const dataOrderItem = insertProductDataIntoOrderItem(response.data.data, rootGetters)
                commit('addOrderItem', dataOrderItem);

                // const order = getters.getById(payload.orderId);
                const responseOrder = await httpClient.get(`/orders/${payload.orderId}`)
                const order = responseOrder.data.data;

                const data = await insertProductDataIntoOrder(order, dispatch, rootGetters)
                commit('updateItem', data);
            }
            catch (err) {
                throw new Error("Failed to add order item!");
            }
        },
    },
    mutations: {
        setItems(state, payload) {
            state.orders = payload;
        },
        updateItem(state, payload) {
            let index = state.orders.findIndex(x => x.id === payload.id);
            state.orders[index] = Object.assign(state.orders[index], payload)
        },
        removeItem(state, id) {
            let index = state.orders.findIndex(x => x.id === id);
            state.orders.splice(index, 1);
        },
        removeOrderItem(state, orderId, productId) {
            let orderIndex = state.orders.findIndex(x => x.id === orderId);
            let orderItemIndex = state.orders[orderIndex].orderItems.findIndex(x => x.productId === productId)
            state.orders[orderIndex].orderItems.splice(orderItemIndex, 1);
        },
        addItem(state, payload) {
            state.orders.push(payload);
        },
        addOrderItem(state, payload) {
            let orderIndex = state.orders.findIndex(x => x.id === payload.orderId);
            state.orders[orderIndex].orderItems.push(payload);
        },
    }
}
