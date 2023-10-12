import { useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { FunctionAddFamily  } from "../../Redux/Action";
import "react-datepicker/dist/react-datepicker.css";
import Relation from './../Common/RelationCombo';
import Country from './../Common/CountryCombo';
import { useDispatch } from "react-redux";
import DatePicker from 'react-datepicker';
import "./Family.css";


const FamilyAdd = () => {
    const [firstName, firstNamechange] = useState('');
    const [lastName, lastNamechange] = useState('');
    const [dateOfBirth, dateOfBirthchange] = useState('');
    const [nationalityId, nationalitychange] = useState(0);
    const [relationshipId, relationshipchange] = useState(0);

    const dispatch = useDispatch();
    const navigate = useNavigate();
    const { code } = useParams();



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
        if (firstName == '' || lastName == '' || dateOfBirth == '' || relationshipId == 0) {
            alert("Please Provide mandatory fields");
            return;
        }
        const familyobj = { firstName, lastName, dateOfBirth, nationalityId, relationshipId };
        dispatch(FunctionAddFamily(familyobj, code));
        navigate('/family/' + code);
    }


    return (
        <div>
            <form onSubmit={handlesubmit}>
                <div className="card">
                    <div className="card-header" style={{ textAlign: 'left' }}>
                        <h2>Add Family Member</h2>
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
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Country </label><br />
                                    <Country childToParent={getCountryValue} countryValue={nationalityId} />
                                </div>
                            </div>
                            <div className="col-lg-12">
                                <div className="form-group">
                                    <label>Relationship to Student</label> <label style={{ color: 'red', fontSize: 10 + 'pt' }}>*</label> <br />
                                    <Relation childToParent={getRelationshipValue} relationshipValue={relationshipId} />
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

export default FamilyAdd;