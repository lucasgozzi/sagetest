import api from './api';

class PeopleService {
    prefix = 'people';
    getPeoples(filter) {
        return api.get(`${this.prefix}`, { query: {} });
    }
    getPeople(id) {
        return api.get(`${this.prefix}/${id}`);
    }
    removePeople(id) {
        return api.delete(`${this.prefix}/${id}`);
    }
    addPeople(people) {
        return api.post(`${this.prefix}`, people);
    }
    updatePeople(id, people) {
        return api.put(`${this.prefix}/${id}`, people);
    }
}

export default new PeopleService();