import httpClient from '@/services/http-client'

export default {
    namespaced: true,
    state: {
        statuses: [],
    },
    getters: {
        getAll(state) {
            return state.statuses;
        },
        getById: state => id => {
            return state.statuses.find(x => x.id === id);
        },
        getByName: state => name => {
            return state.statuses.find(x => x.name === name);
        }
    },
    actions: {
        async fetchAll({ commit }) {
            try {
                const response = await httpClient.get('/statuses?limit=100')
                commit('SET', response.data.data);
            }
            catch (err) {
                throw new Error("Failed to fetch order statuses from API!")
            }
        }
    },
    mutations: {
        SET(state, payload) {
            state.statuses = payload;
        }
    }
}
