import { FetchFamilyList, RemoveFamily, getRoleObject } from "../../Redux/Action";
import { ToastContainer, toast } from 'react-toastify';
import { Link, useParams } from "react-router-dom";
import { formatDate } from './../../features';
import { connect } from "react-redux";
import { useEffect } from "react";

const Familylisting = (props) => {

    const { code } = useParams();

    useEffect(() => {
        props.getRole();
        props.loadFamily(code);
    }, [])

    const handledelete = (id) => {
        if (window.confirm(`Do you want to remove family member with id: ${id}?`)) {
            props.removefamily(id);

            console.log('load fired');
            const index = props.family.familyList.findIndex((item) => item.id == id);
            console.log('index ' + index);
            props.family.familyList.splice(index, 1);
            toast.success('Family removed successfully.');
        }
    }

    return (
        props.family.loading ? <div><h2>Loading...</h2></div> :
            props.family.errmessage ? <div><h2>{props.family.errmessage}</h2></div> :

                <div>
                    <div className="card">
                        <div className="card-header" >
                            <div className="row">
                                <div className="col-md-5">
                                    <h3>Family Member Listing</h3>
                                </div>
                                <div className="col-md-5">
                                    <p>Role: &nbsp; {props.role.loggedRole}</p>
                                </div>
                                <div className="col-md-2">
                                    <Link to={'/family/add/' + code} className="btn btn-success">Add Family [+]</Link>
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
                                        <td>Realtion</td>
                                        <td>Country</td>
                                        <td>Action</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        props.family.familyList && props.family.familyList.map(item =>
                                            <tr key={item.id}>
                                                <td>{item.id}</td>
                                                <td>{item.firstName} {item.lastName}</td>
                                                <td>{formatDate(item.dateOfBirth)}</td>
                                                <td>{item.relationshipName}</td>
                                                <td>{item.countryName}</td>
                                                <td>
                                                    {
                                                        props.role.loggedRole === "admin" ?
                                                            <Link to={'/family/view/' + item.id} className="btn btn-primary">View</Link> :
                                                            <div>
                                                                <Link to={'/family/edit/' + item.id} className="btn btn-primary">Edit</Link>
                                                                <button onClick={() => { handledelete(item.id) }} className="btn btn-danger">Delete</button>
                                                            </div>
                                                    }
                                                </td>
                                            </tr>
                                        )
                                    }
                                </tbody>
                            </table>
                        </div>
                        <ToastContainer />
                    </div>
                </div>
    );
}

const mapStateToProps = (state) => {
    return {
        family: state.family,
        role: state.role
    }
}
const mapDispatchToProps = (dispatch) => {
    return {
        loadFamily: (code) => dispatch(FetchFamilyList(code)),
        removefamily: (code) => dispatch(RemoveFamily(code)),
        getRole: () => dispatch(getRoleObject())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(Familylisting);