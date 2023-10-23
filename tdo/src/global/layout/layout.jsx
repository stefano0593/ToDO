import './layout.css';
export const Layout = (page) => {
    return (
        <div className="layout-container">
            <div className="navbar"></div>
            <div className="page">{page}</div>
        </div>
    );
};
