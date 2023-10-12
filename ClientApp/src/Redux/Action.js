import axios from "axios"
import {
    GET_ROLE, SET_ROLE,
    MAKE_REQUEST, FAIL_REQUEST,
    GET_STUDENT_LIST, GET_STUDENT, ADD_STUDENT, UPDATE_STUDENT, DELETE_STUDENT, REFRESH_STUDENT,
    GET_FAMILY_LIST, GET_FAMILY, ADD_FAMILY, UPDATE_FAMILY, DELETE_FAMILY
} from "./ActionType"

const API_URL = 'https://localhost:7108/api'

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
export const deleteStudent = () => {
    return {
        type: DELETE_STUDENT
    }
}
export const refreshStd = (data) => {
    return {
        type: REFRESH_STUDENT,
        payload: data
    }
}

export const getFamilyList = (data) => {
    return {
        type: GET_FAMILY_LIST,
        payload: data
    }
}
export const getFamily = (data) => {
    return {
        type: GET_FAMILY,
        payload: data
    }
}
export const addFamily = (data) => {
    return {
        type: ADD_FAMILY,
        payload: data
    }
}
export const updateFamily = (data) => {
    return {
        type: UPDATE_FAMILY,
        payload: data
    }
}
export const deleteFamily = () => {
    return {
        type: DELETE_FAMILY
    }
}



export const getRoleObject = () => {
    return async (dispatch) => {
        dispatch(getRole());
    }
}
export const setRoleObject = (role) => {
    return (dispatch) => {
        dispatch(setRole(role));
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
export const FunctionAddStudent = (data) => {
    return async (dispatch) => {
        dispatch(makeRequest());
        try {
            const response = await axios.post(`${API_URL}/Student`, data);
            const obj = await response.data;
            console.log(obj);
            const newObj = {
                id: obj.ID,
                firstName: obj.firstName,
                lastName: obj.lastName,
                dateOfBirth: obj.dateOfBirth,
                nationalityId: 0
            };            
            return dispatch(await refreshStd(newObj));
        }
        catch (err) {
            return dispatch(failRequest(err.message));
        }
    }
}
export const FunctionUpdateStudent = (data, code) => {
    return async (dispatch) => {
        dispatch(makeRequest());
        try {
            const response = await axios.put(`${API_URL}/Student/${code}`, data);
            const obj = await response.data;
            console.log(obj);
            return dispatch(updateStudent());
        }
        catch (err) {
            return dispatch(failRequest(err.message));
        }
    }
}
export const FunctionRemoveStudent = (code) => {
    return async (dispatch) => {
        dispatch(makeRequest());
        try {
            const response = await axios.delete(`${API_URL}/Student/${code}`);
            const obj = await response.data;
            console.log(obj);
            return dispatch(deleteStudent());
        }
        catch (err) {
            return dispatch(failRequest(err.message));
        }
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
export const FunctionAddFamily = (data, code) => {
    return async (dispatch) => {
        dispatch(makeRequest());
        try {
            const response = await axios.post(`${API_URL}/Student/${code}/FamilyMembers`, data);
            const obj = await response.data;
            const newObj = {
                id: obj.ID,
                firstName: obj.firstName,
                lastName: obj.lastName,
                dateOfBirth: obj.dateOfBirth,
                relationshipId: obj.relationshipId,
                relationshipName: obj.relationshipName,
                nationalityId: obj.nationalityId,
                countryName: obj.countryName,
                studentID: code
            };
            console.log(newObj);
            return dispatch(await addFamily(newObj));
        }
        catch (err) {
            return dispatch(failRequest(err.message));
        }
    }
}
export const FunctionUpdateFamily = (data, code) => {
    return async (dispatch) => {
        dispatch(makeRequest());
        try {
            const response = await axios.put(`${API_URL}/FamilyMembers/${code}`, data);
            const obj = await response.data;
            const newObj = {
                id: obj.ID,
                firstName: obj.firstName,
                lastName: obj.lastName,
                dateOfBirth: obj.dateOfBirth,
                relationshipId: obj.relationshipId,
                relationshipName: obj.relationshipName,
                nationalityId: obj.nationalityId,
                countryName: obj.countryName,
                studentID: code
            };
            //console.log(newObj);            
            return dispatch(updateFamily(newObj));
        }
        catch (err) {
            return dispatch(failRequest(err.message));
        }
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
