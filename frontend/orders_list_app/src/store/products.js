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
        }
    },
    mutations: {
        SET(state, payload) {
            state.products = payload;
        }
    }
}
