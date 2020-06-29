import httpClient from '@/services/http-client'

export default {
    namespaced: true,
    state: {
        products: [],
    },
    getters: {
        getAll(state) {
            return state.products;
        },
        getById: state => id => {
            return state.products.find(todo => todo.id === id);
        }
    },
    actions: {
        fetchAll(context) {
            return new Promise((resolve, reject) => {
                httpClient.get('/products?limit=100')
                    .then(response => {
                        context.commit('SET', response.data.data);
                        resolve(response.data.data)
                    })
                    .catch(error => {
                        console.log(error);
                        reject(error);
                    });
            })
        },
        // get(payload) {
        //     return httpClient.get('/products/${payload.id}')
        // },
    },
    mutations: {
        SET(state, payload) {
            state.products = payload;
        },
        // ADD(state, payload) {
        //     state.products.push(payload);
        // },
        // REMOVE(state, index) {
        //     state.products.splice(index, 1);
        // }
    }
}
