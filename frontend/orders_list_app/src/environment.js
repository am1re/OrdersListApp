const { VUE_APP_API_BASE_URL, NODE_ENV = '' } = process.env;

const environment = NODE_ENV.toLowerCase();
const apiBaseUrl = VUE_APP_API_BASE_URL || 'http://localhost:5000/api';

export default { environment, apiBaseUrl };
