import React from 'react';
import './layout.css';

export const Layout = ({page}: any) => {
    return (
        <div className="layout-container">
            <div className="navbar"></div>
            <div className="page">{ page }</div>
        </div>
    );
};
