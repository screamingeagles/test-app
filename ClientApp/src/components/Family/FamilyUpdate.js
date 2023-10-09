import { FetchFamilyObject, FunctionUpdateFamily } from "../../Redux/Action";
import { Link, useNavigate, useParams } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import "react-datepicker/dist/react-datepicker.css";
import Relation from './../Common/RelationCombo';
import Country from './../Common/CountryCombo';
import { useEffect, useState } from "react";
import DatePicker from 'react-datepicker';
import "./Family.css";


const FamilyUpdate = () => {
    const [id, idchange] = useState(0);
    const [firstName, firstNamechange] = useState('');
    const [lastName, lastNamechange] = useState('');
    const [dateOfBirth, dateOfBirthchange] = useState('');
    const [nationalityId, nationalitychange] = useState(0);
    const [relationshipId, relationshipchange] = useState(0);
    const [studentId, studentIdchange] = useState(0);

    const dispatch = useDispatch();
    const navigate = useNavigate();
    const { code } = useParams();

    const familyobj = useSelector((state) => state.family.familyObj);

    // here get the selected Relation
    // from RelationCombo component
    const getRelationshipValue = (data) => {
        // get id of the relation and set state
        relationshipchange(data);
    }


    // here get the selected country
    // from CountryCombo component
    const getCountryValue = (data) => {
        // get id of the country and set state
        nationalitychange(data);
    }


    const handlesubmit = (e) => {
        e.preventDefault();
        const familyobj = {
            "ID": id,
            "firstName": firstName,
            "lastName": lastName,
            "dateOfBirth": new Date(dateOfBirth),
            "nationalityId": nationalityId,
            "relationshipId": relationshipId
        };
        dispatch(FunctionUpdateFamily(familyobj, code));
        navigate('/family/' + studentId);
    }

    useEffect(() => {
        dispatch(FetchFamilyObject(code));
    }, [])

    useEffect(() => {
        if (familyobj) {
            idchange(familyobj.ID);
            firstNamechange(familyobj.firstName);
            lastNamechange(familyobj.lastName);
            dateOfBirthchange(Date.parse(familyobj.dateOfBirth));
            nationalitychange(familyobj.nationalityId);
            relationshipchange(familyobj.relationshipId);
            studentIdchange(familyobj.studentID);
        }
    }, [familyobj])


    return (
        <div>
            <form onSubmit={handlesubmit}>
                <div className="card">
                    <div className="card-header" style={{ textAlign: 'left' }}>
                        <h2>Update Family Member Details</h2>
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
                                    <DatePicker selected={dateOfBirth}
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
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Relationship to Student</label><br />
                                    <Relation childToParent={getRelationshipValue} countryValue={relationshipId} />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="card-footer" style={{ textAlign: 'left' }}>
                        <button className="btn btn-primary" type="submit">Submit</button> |
                        <Link className="btn btn-danger" to={'/family/' + studentId}>Back</Link>
                    </div>

                </div>
            </form>
        </div>
    );
}

export default FamilyUpdate;