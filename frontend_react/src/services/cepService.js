import axios from 'axios';

const api = axios.create({
    baseURL: 'https://webmaniabr.com/api/1/'
});
const app_key = 'j9Z3y5CJCYuTXWe2Uvd4TSZw9QPQ6AZ7';
const app_secret = 'Yp8xXxfVuIrBKDhj8TGDbm7uY9SIWg4IRH0WuzdJVEmFCXyO';

const searchZipcode = (cep) => {
    return api.get(`cep/${cep}/?app_key=${app_key}&app_secret=${app_secret}`);
}

export default searchZipcode;

