import { FetchFamilyObject } from "../../Redux/Action";
import { useDispatch, useSelector } from "react-redux";
import { Link, useParams } from "react-router-dom";
import "react-datepicker/dist/react-datepicker.css";
import { formatDate } from './../../features';
import { useEffect, useState } from "react";

const FamilyUpdate = () => {
    const [id, idchange] = useState(0);
    const [firstName, firstNamechange] = useState('');
    const [lastName, lastNamechange] = useState('');
    const [dateOfBirth, dateOfBirthchange] = useState('');
    const [countryName, countrynamechange] = useState('');
    const [relationshipName, relationshipnamechange] = useState('');
    const [studentId, studentIdchange] = useState(0);

    const dispatch = useDispatch();
    const { code } = useParams();

    const familyobj = useSelector((state) => state.family.familyObj);

    useEffect(() => {
        dispatch(FetchFamilyObject(code));
    }, [])

    useEffect(() => {
        if (familyobj) {
            idchange(familyobj.ID);
            firstNamechange(familyobj.firstName);
            lastNamechange(familyobj.lastName);
            dateOfBirthchange(Date.parse(familyobj.dateOfBirth));
            countrynamechange(familyobj.countryName);
            relationshipnamechange(familyobj.relationshipName);
            studentIdchange(familyobj.studentID);
        }
    }, [familyobj])


    return (
        <div>
            <form>
                <div className="card">
                    <div className="card-header" style={{ textAlign: 'left' }}>
                        <h2>View Family Member Details</h2>
                    </div>
                    <div className="card-body" style={{ textAlign: 'left' }}>
                        <div className="row">
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>ID</label>
                                    <input value={id || ''} disabled="disabled" className="form-control"></input>
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>First Name</label>
                                    <input value={firstName || ''} disabled="disabled" className="form-control"></input>
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
                                    <input value={formatDate(dateOfBirth) || ''} disabled="disabled" className="form-control"></input>
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Country</label><br />
                                    <input value={countryName || ''} disabled="disabled" className="form-control"></input>
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Relationship to Student</label><br />
                                    <input value={relationshipName || ''} disabled="disabled" className="form-control"></input>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="card-footer" style={{ textAlign: 'left' }}>
                        <Link className="btn btn-danger" to={'/family/' + studentId}>Back</Link>
                    </div>

                </div>
            </form>
        </div>
    );
}

export default FamilyUpdate;