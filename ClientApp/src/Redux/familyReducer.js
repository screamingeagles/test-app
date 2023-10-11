import { MAKE_REQUEST, FAIL_REQUEST, GET_FAMILY_LIST, GET_FAMILY, ADD_FAMILY, UPDATE_FAMILY, DELETE_FAMILY } from "./ActionType"

const initialFamilystate = {
    loading: true,
    familyList: [],
    familyObj: {},
    errmessage: ''
}

export const familyReducer = (state = initialFamilystate, action) => {
    switch (action.type) {
        case MAKE_REQUEST:
            return {
                ...state,
                loading: true
            }
        case FAIL_REQUEST:
            return {
                ...state,
                loading: false,
                errmessage: action.payload
            }
        case GET_FAMILY_LIST:
            return {
                loading: false,
                errmessage: '',
                familyList: action.payload,
                familyObj: {}
            }
        case GET_FAMILY: return {
            ...state,
            loading: false,
            familyObj: action.payload
        }
        case ADD_FAMILY: return {
            loading: false,
            errmessage: '',
            familyList: [...state.familyList, action.payload],
            familyObj: {}
        }
        case UPDATE_FAMILY: return {
            ...state,
            loading: false
        }
        case DELETE_FAMILY: return {
            ...state,
            loading: false
        }
        default: return state
    }
}