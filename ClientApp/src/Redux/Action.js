import axios from "axios"
import {
    MAKE_REQUEST, FAIL_REQUEST,
    GET_STUDENT_LIST, GET_STUDENT, ADD_STUDENT, UPDATE_STUDENT,
    GET_FAMILY, ADD_FAMILY, GET_FAMILY_LIST, DELETE_FAMILY,
    GET_ROLE, SET_ROLE
} from "./ActionType"

const API_URL = 'https://localhost:7108/api'

export const makeRequest = () => {
    return {
        type: MAKE_REQUEST
    }
}
export const failRequest = (err) => {
    return {
        type: FAIL_REQUEST,
        payload: err
    }
}
export const getStudentList = (data) => {
    return {
        type: GET_STUDENT_LIST,
        payload: data
    }
}
export const getStudent = (data) => {
    return {
        type: GET_STUDENT,
        payload: data
    }
}
export const addStudent = () => {
    return {
        type: ADD_STUDENT
    }
}
export const updateStudent = () => {
    return {
        type: UPDATE_STUDENT
    }
}
export const getFamily = (data) => {
    return {
        type: GET_FAMILY,
        payload: data
    }
}
export const addFamily = () => {
    return {
        type: ADD_FAMILY
    }
}
export const getFamilyList = (data) => {
    return {
        type: GET_FAMILY_LIST,
        payload: data
    }
}
export const deleteFamily = () => {
    return {
        type: DELETE_FAMILY
    }
}

export const getRole = () => {
    return {
        type: GET_ROLE
    }
}
export const setRole = (data) => {
    return {
        type: SET_ROLE,
        payload: data
    }
}


export const FetchStudentList = () => {
    return async (dispatch) => {
        dispatch(makeRequest());
        await axios.get(`${API_URL}/Student`).then(res => {
            const studentList = res.data;
            dispatch(getStudentList(studentList));
        }).catch(err => {
            dispatch(failRequest(err.message))
        })
    }
}
export const FunctionAddStudent = (data) => {
    return (dispatch) => {
        dispatch(makeRequest());
        axios.post(`${API_URL}/Student`, data).then(res => {
            dispatch(addStudent());
        }).catch(err => {
            dispatch(failRequest(err.message))
        })
    }
}
export const FunctionUpdateStudent = (data, code) => {
    return (dispatch) => {
        dispatch(makeRequest());
        axios.put(`${API_URL}/Student/${code}`, data).then(res => {
            dispatch(updateStudent());
        }).catch(err => {
            dispatch(failRequest(err.message))
        })
    }
}
export const FetchStudentObject = (code) => {
    return (dispatch) => {
        dispatch(makeRequest());
        axios.get(`${API_URL}/Student/${code}/`).then(res => {
            const studentObject = res.data;
            dispatch(getStudent(studentObject));
        }).catch(err => {
            dispatch(failRequest(err.message))
        })
    }
}

export const FunctionAddFamily = (data, code) => {
    return (dispatch) => {
        dispatch(makeRequest());
        axios.post(`${API_URL}/Student/${code}/FamilyMembers`, data).then(res => {
            dispatch(addFamily());
        }).catch(err => {
            dispatch(failRequest(err.message))
        })
    }
}
export const FetchFamilyObject = (code) => {
    return (dispatch) => {
        dispatch(makeRequest());
        axios.get(`${API_URL}/FamilyMembers/${code}/`).then(res => {
            const familyObject = res.data;
            dispatch(getFamily(familyObject));
        }).catch(err => {
            dispatch(failRequest(err.message))
        })
    }
}
export const FetchFamilyViewObject = (code) => {
    return (dispatch) => {
        dispatch(makeRequest());
        axios.get(`${API_URL}/FamilyMembers/${code}/`).then(res => {
            const familyObject = res.data;
            dispatch(getFamily(familyObject));
        }).catch(err => {
            dispatch(failRequest(err.message))
        })
    }
}

export const FunctionUpdateFamily = (data, code) => {
    return (dispatch) => {
        dispatch(makeRequest());
        axios.put(`${API_URL}/FamilyMembers/${code}`, data).then(res => {
            dispatch(addFamily());
        }).catch(err => {
            dispatch(failRequest(err.message))
        })
    }
}
export const FetchFamilyList = (code) => {
    return async (dispatch) => {
        dispatch(makeRequest());
        await axios.get(`${API_URL}/FamilyMembers/List/${code}`).then(res => {
            const familyList = res.data;
            dispatch(getFamilyList(familyList));
        }).catch(err => {
            dispatch(failRequest(err.message))
        })
    }
}
export const RemoveFamily = (code) => {
    return (dispatch) => {
        dispatch(makeRequest());
        axios.delete(`${API_URL}/FamilyMembers/${code}`).then(res => {
            dispatch(deleteFamily());
        }).catch(err => {
            dispatch(failRequest(err.message))
        })
    }
}

export const setRoleObject = (role) => {
    return (dispatch) => {
        dispatch(setRole(role));
    }
}
export const getRoleObject = () => {
    return async (dispatch) => {
        dispatch(getRole());
    }
}