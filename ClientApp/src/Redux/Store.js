import { configureStore, combineReducers } from "@reduxjs/toolkit";
import logger from "redux-logger";
import thunk from "redux-thunk";
import { studentReducer } from "./studentReducer";
import { familyReducer } from "./familyReducer";
import { roleReducer } from "./roleReducer";


const rootreducer = combineReducers({
    student: studentReducer,
    family: familyReducer,
    role: roleReducer
});
const Store = configureStore({ reducer: rootreducer, middleware: [thunk, logger] })
export default Store;