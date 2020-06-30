import httpClient from '@/services/http-client'

const insertProductDataIntoOrder = async function (data, dispatch, rootGetters) {
    const process = function (order) {
        order.status = order.status.name
        order.total = 0
        order.orderItems.forEach(orderItem => {
            order.total += orderItem.productPrice

            let product = rootGetters['products/getById'](orderItem.productId);
            orderItem.photoUrl = product.photoUrl;
            orderItem.name = product.name;
        })
    }

    await dispatch("products/fetchAll", null, { root: true })

    if (Array.isArray(data))
        data.forEach(order => process(order))
    else process(data)

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
        }
    },
    actions: {
        fetchAll({ dispatch, commit, rootGetters }) {
            return httpClient.get('/orders?limit=100')
                .then(async (response) => {
                    return await insertProductDataIntoOrder(response.data.data, dispatch, rootGetters)
                })
                .then(data => {
                    commit('SET', data);
                    return data
                })
                .catch(error => {
                    console.log(error);
                    return error
                });
        },
        updateItem({ dispatch, commit, rootGetters }, payload) {
            payload.orderItems.forEach(async e => {
                await httpClient.put(`/orders/${payload.id}/items`, e)
                    .then((response) => {
                        console.log(response)
                    })
            })

            return httpClient.put(`/orders/${payload.id}`, payload)
                .then(async (response) => {
                    return await insertProductDataIntoOrder(response.data.data, dispatch, rootGetters)
                })
                .then((data) => {
                    console.log(data)
                    commit('updateItem', data);
                });
        },
        deleteItem({ commit }, payload) {
            httpClient.delete(`/orders/${payload.id}`, payload)
                .then((response) => {
                    if (response.status == 204)
                        commit('REMOVE', payload.id);
                })
        },
        deleteOrderItem({ commit }, payload) {
            httpClient.delete(`/orders/${payload.orderId}/items`, { data: payload })
                .then((response) => {
                    if (response.status == 204)
                        commit('removeOrderItem', payload.orderId, payload.productId);
                })
        },
    },
    mutations: {
        SET(state, payload) {
            state.orders = payload;
        },
        updateItem(state, payload) {
            let index = state.orders.findIndex(x => x.id === payload.id);
            state.orders[index] = Object.assign(state.orders[index], payload)
        },
        REMOVE(state, id) {
            let index = state.orders.findIndex(x => x.id === id);
            state.orders.splice(index, 1);
        },
        removeOrderItem(state, orderId, productId) {
            let index = state.orders.findIndex(x => x.id === orderId);
            let index2 = state.orders[index].orderItems.findIndex(x => x.productId === productId)
            state.orders[index].orderItems.splice(index2, 1);
        },
        // ADD(state, payload) {
        //     state.products.push(payload);
        // },
    }
}
