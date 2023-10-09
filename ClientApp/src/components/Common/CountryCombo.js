import React from 'react';
import { getData } from './../../features';

class CountryComboComponent extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            countryList: [],
            value: this.props.countryValue
        };
    }

    async componentDidMount() {
        const obj = await getData("Nationalities");
        this.setState(prevState => ({
            ...prevState.value,
            countryList: obj
        }));
    }

    componentDidUpdate(prevProps) {
        if (prevProps.countryValue !== this.props.countryValue) {
            this.setState(prevState => ({
                ...prevState.countryList,
                value: this.props.countryValue
            }));
        }
    }

    setCountryValue(event) {
        this.setState({ value: event.target.value }, function () {
            this.props.childToParent(event.target.value);
        });
    }

    render() {
        const countryRows = this.state.countryList?.length > 0 && this.state.countryList.map((item) =>
            <option key={item.nationalityId} value={item.nationalityId}>{item.countryName}</option>
        );

        return (
            <select className="custom-select rounded-0 form-control"
                onChange={(e) => this.setCountryValue(e)}
                value={this.state.value}
                id="SelectCountry">
                {countryRows}
            </select>
        )
    }
}
export default CountryComboComponent;