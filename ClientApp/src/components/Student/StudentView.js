import { useEffect, useState } from "react";
import { FetchStudentObject } from "../../Redux/Action";
import { useDispatch, useSelector } from "react-redux";
import "react-datepicker/dist/react-datepicker.css";
import { Link, useParams } from "react-router-dom";
import DatePicker from 'react-datepicker';

const ViewStudent = () => {
    const [id, idchange] = useState(0);
    const [firstName, firstNamechange] = useState('');
    const [lastName, lastNamechange] = useState('');
    const [dateOfBirth, dateOfBirthchange] = useState('');
    const dispatch = useDispatch();
    const { code } = useParams();

    const studentobj = useSelector((state) => state.student.studentObj)

    useEffect(() => {
        dispatch(FetchStudentObject(code));
    }, [])

    useEffect(() => {
        if (studentobj) {
            idchange(studentobj.ID);
            firstNamechange(studentobj.firstName);
            lastNamechange(studentobj.lastName);
            dateOfBirthchange(Date.parse(studentobj.dateOfBirth));
        }
    }, [studentobj])

    return (
        <div>
            <form>
                <div className="card">
                    <div className="card-header" style={{ textAlign: 'left' }}>
                        <h2>Add User</h2>
                    </div>
                    <div className="card-body" style={{ textAlign: 'left' }}>
                        <div className="row">
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Id</label>
                                    <input value={id || ''} disabled="disabled" className="form-control"></input>
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>First Name</label>
                                    <input value={firstName || ''} className="form-control" disabled="disabled" ></input>
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Last Name</label>
                                    <input value={lastName || ''} disabled="disabled" className="form-control"></input>
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Date of Birth</label><br />
                                    <DatePicker selected={dateOfBirth || ''}
                                        disabled="disabled"
                                        dateFormat="dd-MMM-yyyy"
                                        wrapperClassName="datepicker"
                                        className="form-control" style={{ with: 100 + '%' }} />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="card-footer" style={{ textAlign: 'left' }}>
                        <Link className="btn btn-danger" to={'/students'}>Back</Link>
                    </div>

                </div>
            </form>
        </div>
    );
}

export default ViewStudent;