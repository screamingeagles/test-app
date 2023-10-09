import { useEffect, useState } from "react";
import { FetchStudentObject, FunctionUpdateStudent } from "../../Redux/Action";
import { Link, useNavigate, useParams } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import "react-datepicker/dist/react-datepicker.css";
import Country from './../Common/CountryCombo';
import DatePicker from 'react-datepicker';
import "./Student.css";

const StudentUpdate = () => {
    const [id, idchange] = useState(0);
    const [firstName, firstNamechange] = useState('');
    const [lastName, lastNamechange] = useState('');
    const [dateOfBirth, dateOfBirthchange] = useState(new Date());
    const [nationalityId, nationalitychange] = useState(0);
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const { code } = useParams();

    const studentobj = useSelector((state) => state.student.studentObj)

    // here get the selected country
    // from CountryCombo component
    const getCountryValue = (data) => {
        // get id of the country and set state
        nationalitychange(data);
    }

    const handlesubmit = (e) => {
        e.preventDefault();
        const studentobj = {
            "ID": id,
            "firstName": firstName,
            "lastName": lastName,
            "dateOfBirth": new Date(dateOfBirth),
            "nationalityId": nationalityId
        };
        dispatch(FunctionUpdateStudent(studentobj, id));
        navigate('/students');
    }

    useEffect(() => {
        dispatch(FetchStudentObject(code));
    }, [])

    useEffect(() => {
        if (studentobj) {
            idchange(studentobj.ID);
            firstNamechange(studentobj.firstName);
            lastNamechange(studentobj.lastName);
            nationalitychange(studentobj.nationalityId);
            dateOfBirthchange(Date.parse(studentobj.dateOfBirth));
        }
    }, [studentobj])

    return (
        <div>
            <form onSubmit={handlesubmit}>
                <div className="card">
                    <div className="card-header" style={{ textAlign: 'left' }}>
                        <h2>Edit User Details</h2>
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
                                    <input value={firstName || ''} onChange={e => firstNamechange(e.target.value)} className="form-control"></input>
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Last Name</label>
                                    <input value={lastName || ''} onChange={e => lastNamechange(e.target.value)} className="form-control"></input>
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Date of Birth</label><br />
                                    <DatePicker selected={dateOfBirth || ''}
                                        onChange={(date) => dateOfBirthchange(date)}
                                        dateFormat="dd-MMM-yyyy"
                                        wrapperClassName="datepicker"
                                        className="form-control" />
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Country</label><br />
                                    <Country childToParent={getCountryValue} countryValue={nationalityId} />
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

export default StudentUpdate;