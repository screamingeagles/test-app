import React from 'react';
import { getData } from './../../features';

class RelationComboComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            relationList: [],
            value: this.props.relationshipValue
        };
    }

    async componentDidMount() {

        const obj = await getData("Relationship");

        this.setState(prevState => ({
            ...prevState.value,
            relationList: obj
        }));
    }

    componentDidUpdate(prevProps) {
        if (prevProps.relationshipValue !== this.props.relationshipValue) {
            this.setState(prevState => ({
                ...prevState.relationList,
                value: this.props.relationshipValue
            }));
        }
    }

    setRelationshipValue(event) {
        this.setState({ value: event.target.value }, function () {
            this.props.childToParent(event.target.value);
        });
    }

    render() {
        const countryRows = this.state.relationList && this.state.relationList.map((item) =>
            <option key={item.relationshipId} value={item.relationshipId}>{item.relationshipName}</option>
        );

        return (
            <select className="custom-select rounded-0 form-control"
                onChange={(e) => this.setRelationshipValue(e)}
                value={this.state.value}
                id="SelectRelationship">
                {countryRows}
            </select>
        )
    }
}
export default RelationComboComponent;