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
            return state.products.find(x => x.id === id);
        }
    },
    actions: {
        async fetchAll(context) {
            try {
                const response = await httpClient.get('/products?limit=100')
                context.commit('SET', response.data.data);
            }
            catch (err) {
                throw new Error("Failed to fetch prodcuts from API!")
            }
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
