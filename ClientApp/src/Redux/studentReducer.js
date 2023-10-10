import { MAKE_REQUEST, FAIL_REQUEST, GET_STUDENT_LIST, GET_STUDENT, ADD_STUDENT, UPDATE_STUDENT, DELETE_STUDENT } from "./ActionType"

const initialStudentstate = {
    loading: true,
    studentList: [],
    studentObj: {},
    errmessage: ''
}

export const studentReducer = (state = initialStudentstate, action) => {
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
        case GET_STUDENT_LIST:
            return {
                loading: false,
                errmessage: '',
                studentList: action.payload,
                studentObj: {}
            }
        case GET_STUDENT: return {
            ...state,
            loading: false,
            studentObj: action.payload
        }
        case ADD_STUDENT: return {
            ...state,
            loading: false
        }
        case UPDATE_STUDENT: return {
            ...state,
            loading: false
        }
        case DELETE_STUDENT: return {
            ...state,
            loading: false
        }
        default: return state
    }
}