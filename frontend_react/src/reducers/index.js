import { ADD_PEOPLE } from "../constants/action-types";

const initialState = {
    peoples: []
};

function rootReducer(state = initialState, action) {
    if (action.type === ADD_PEOPLE) {
        return Object.assign({}, state, {
            peoples: state.peoples.concat(action.payload)
        });
    }
    return state;
};

export default rootReducer;