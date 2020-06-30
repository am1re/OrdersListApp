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
        fetchAll(context) {
            return httpClient.get('/statuses?limit=100')
                .then(response => {
                    context.commit('SET', response.data.data);
                })
                .catch(error => {
                    console.log(error);
                })
        }
    },
    mutations: {
        SET(state, payload) {
            state.statuses = payload;
        }
    }
}
