import { GET_ROLE, SET_ROLE } from "./ActionType"

const initialRolestate = {
    loggedRole: 'admin'
}

export const roleReducer = (state = initialRolestate, action) => {
    switch (action.type) {
        case GET_ROLE:
            return {
                ...state
            }
        case SET_ROLE:
            return {
                ...state,
                loggedRole: action.payload
            }
        default: return state
    }
}