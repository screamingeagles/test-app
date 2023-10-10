import { FunctionAddStudent } from "../../Redux/Action";
import "react-datepicker/dist/react-datepicker.css";
import { Modal, Button } from "react-bootstrap";
import { useDispatch } from "react-redux";
import DatePicker from 'react-datepicker';
import { useState } from "react";
import "./Student.css"

const StudentAdd = () => {
    const [show, setShow] = useState(false);
    const [firstName, firstNamechange] = useState('');
    const [lastName, lastNamechange] = useState('');
    const [dateOfBirth, dateOfBirthchange] = useState('');
    const dispatch = useDispatch();

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const handlesubmit = async (e) => {
        e.preventDefault();
        const studentobj = { firstName, lastName, dateOfBirth };
        await dispatch(await FunctionAddStudent(studentobj));
        setShow(false);
    }
    
    return (
        <>
            <button type='button' className='btn btn-success'
                onClick={handleShow}
                data-toggle='modal'
                data-target='#modal-lg'>Add Student [+]</button>

            <Modal show={show} onHide={handleClose} className="modal-xl">
                <Modal.Header closeButton>
                    <Modal.Title>Add New Student</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    {/* save card body start  */}
                    <div className="card-body">
                        <div className="row">
                            <div className="col-sm-12">
                                <div className="form-group">
                                    <label htmlFor="InputFirstName">First Name</label>
                                    <input value={firstName || ''}
                                        className="form-control"
                                        placeholder="Enter First Name"
                                        onChange={e => firstNamechange(e.target.value)} ></input>
                                </div>
                            </div>
                            <div className="col-sm-12">
                                <div className="form-group">
                                    <label htmlFor="InputLastName">Last Name</label>
                                    <input value={lastName || ''}
                                        className="form-control"
                                        placeholder="Enter Last Name"
                                        onChange={e => lastNamechange(e.target.value)}></input>

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
                        </div>
                    </div>
                    {/* save card body end */}
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={handlesubmit}>
                        Save
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
}

export default StudentAdd;