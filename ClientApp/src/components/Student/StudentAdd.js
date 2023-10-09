import { useState } from "react";
import { FunctionAddStudent } from "../../Redux/Action";
import { Link, useNavigate } from "react-router-dom";
import "react-datepicker/dist/react-datepicker.css";
import { useDispatch } from "react-redux";
import DatePicker from 'react-datepicker';
import "./Student.css"

const StudentAdd = () => {
    const [firstName, firstNamechange] = useState('');
    const [lastName, lastNamechange] = useState('');
    const [dateOfBirth, dateOfBirthchange] = useState('');
    const dispatch = useDispatch();
    const navigate = useNavigate();


    const handlesubmit = (e) => {
        e.preventDefault();
        if (firstName == '' || lastName == '' || dateOfBirth == '') {
            alert("Please Provide mandatory fields");
            return;
        }
        const studentobj = { firstName, lastName, dateOfBirth };
        dispatch(FunctionAddStudent(studentobj));
        navigate('/students');
    }


    return (
        <div>
            <form onSubmit={handlesubmit}>
                <div className="card">
                    <div className="card-header" style={{ textAlign: 'left' }}>
                        <h2>Add User</h2>
                    </div>
                    <div className="card-body" style={{ textAlign: 'left' }}>
                        <div className="row">
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>First Name</label><label style={{ color: 'red', fontSize: 10 + 'pt' }}>*</label>
                                    <input value={firstName} onChange={e => firstNamechange(e.target.value)} className="form-control"></input>
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Last Name</label><label style={{ color: 'red', fontSize: 10 + 'pt' }}>*</label>
                                    <input value={lastName} onChange={e => lastNamechange(e.target.value)} className="form-control"></input>
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Date of Birth</label><label style={{ color: 'red', fontSize: 10 + 'pt' }}>*</label><br />
                                    <DatePicker selected={dateOfBirth}
                                        onChange={(date) => dateOfBirthchange(date)}
                                        dateFormat="dd-MMM-yyyy"
                                        wrapperClassName="datepicker"
                                        className="form-control" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="card-footer" style={{ textAlign: 'left' }}>
                        <button className="btn btn-primary" type="submit">Submit</button> |
                        <Link className="btn btn-danger" to={'/students'}>Back</Link>
                    </div>

                </div>
            </form>
        </div>
    );
}

export default StudentAdd;