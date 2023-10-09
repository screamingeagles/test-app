import { useState, useEffect } from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";
import { formatDate } from './../../features';
import { FetchStudentList, setRoleObject } from "../../Redux/Action";

const Studentlisting = (props) => {

    const [role, rolechange] = useState('admin');

    useEffect(() => {
        props.loadStudent();
    }, [])

    useEffect(() => {
        props.loadStudent();
        props.setRole(role);
    }, [role])

    return (
        props.student.loading ? <div><h2>Loading...</h2></div> :
            props.student.errmessage ? <div><h2>{props.student.errmessage}</h2></div> :

                <div>
                    <div className="card">
                        <div className="card-header" >
                            <div className="row">
                                <div className="col-md-8"></div>
                                <div className="col-md-2">
                                    &nbsp;
                                </div>
                                <div className="col-md-2">
                                    <select value={role} onChange={e => rolechange(e.target.value)} className="form-control">
                                        <option value="admin">Admin</option>
                                        <option value="registrar">Registrar</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div className="card-body">
                            <table className="table table-striped table-bordered" aria-labelledby="tableStudent">
                                <thead className="bg-dark text-white">
                                    <tr>
                                        <td>ID</td>
                                        <td>Name</td>
                                        <td>Date  of Birth</td>
                                        <td>Action</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        props.student.studentList && props.student.studentList.map(item =>
                                            <tr key={item.id}>
                                                <td>{item.id}</td>
                                                <td>{item.firstName} {item.lastName}</td>
                                                <td>{formatDate(item.dateOfBirth)}</td>
                                                <td>
                                                    {
                                                        role == "registrar" ?
                                                            <Link to={'/student/edit/' + item.id} className="btn btn-primary">Edit</Link> :
                                                            <Link to={'/student/view/' + item.id} className="btn btn-success">View</Link>
                                                    }
                                                    <Link to={'/family/' + item.id} className="btn btn-danger">Family</Link>
                                                </td>
                                            </tr>
                                        )
                                    }
                                </tbody>
                            </table>
                        </div>

                    </div>
                </div>
    );
}

const mapStateToProps = (state) => {
    return {
        student: state.student
    }
}
const mapDispatchToProps = (dispatch) => {
    return {
        loadStudent: () => dispatch(FetchStudentList()),
        setRole: (role) => dispatch(setRoleObject(role))
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Studentlisting);