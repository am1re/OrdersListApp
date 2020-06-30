import axios from 'axios';
// import { apiBaseUrl } from '@/environment';

const config = {
  // baseURL: apiBaseUrl
  baseURL: 'http://localhost:5000/api'
};

const httpClient = axios.create(config);

export default httpClient
