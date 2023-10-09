import React, { Component } from 'react';
import { Route, Routes, Navigate } from 'react-router-dom';
// import { Redirect } from 'react-router'
import { Layout } from './components/Layout';
import { Provider } from 'react-redux';
import AppRoutes from './AppRoutes';
import Store from './Redux/Store';
import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
      return (
          <Provider store={Store}>
              <Layout>
                  <Routes>       
                      <Route path="/" element={<Navigate to="/students" />} />

                  {AppRoutes.map((route, index) => {
                    const { element, ...rest } = route;
                    return <Route key={index} {...rest} element={element} />;
                  })}
                </Routes>
               </Layout>
           </Provider>
    );
  }
}
