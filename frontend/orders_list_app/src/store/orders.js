import httpClient from '@/services/http-client'

const processOrders = function(data, context){
    data.forEach(order => {
        order.status = order.status.name
        order.total = 0
        order.orderItems.forEach(orderItem => {
            order.total += orderItem.productPrice

            let product = context.rootGetters['products/getById'](orderItem.productId);
            orderItem.photoUrl = product.photoUrl;
            orderItem.name = product.name;
        });
    });
    console.log(context)
    return data;
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
        fetchAll(context) {
            return new Promise((resolve, reject) => {
                httpClient.get('/orders?limit=100')
                .then(async (response) => {
                    await context.dispatch("products/fetchAll", null, { root: true })
                    return processOrders(response.data.data, context)
                })
                .then(data => {
                    context.commit('SET', data);
                    resolve(data)
                })
                .catch(error => {
                    console.log(error);
                    reject(error)
                });
            })
        },
        // get(payload) {
        //     return httpClient.get('/products/${payload.id}')
        // },
    },
    mutations: {
        SET(state, payload) {
            state.orders = payload;
        },
        // ADD(state, payload) {
        //     state.products.push(payload);
        // },
        // REMOVE(state, index) {
        //     state.products.splice(index, 1);
        // }
    }
}
