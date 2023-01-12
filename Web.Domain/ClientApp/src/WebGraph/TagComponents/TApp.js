import React, { Component } from "react";
import withRouter from "./Utilities/withRouter";
import TLoading from "./Utilities/TLoading";
import { ThemeProvider } from "@mui/material/styles";
import { WebGraph } from "../GenericCoreGraph/WebGraph/WebGraph";
//import GenericWebGraph from "../GenericWebController/GenericWebGraph";

import Button from '@mui/material/Button';

const TDynamicLoader = React.lazy(() => import("./TDynamicLoader"));

class TApp extends Component {
    constructor(props) {
        super();

        this.GetTheme = this.GetTheme.bind(this);

        window.App.App = this;
        this.state = {
            ...this.state,
        };
        WebGraph.Init();
        //GenericWebGraph.Init();
    }


    GetTheme() {
        return window.Themes.DefaultTheme;
    }

    render() {
        return (
            <div style={{ fontFamily: "Montserrat" }}>
                <React.Suspense fallback={<TLoading />}>
                    <ThemeProvider theme={this.GetTheme()}>
                        <TDynamicLoader />
                        <Button variant="contained">Contained</Button>
                        Test
                    </ThemeProvider>
                </React.Suspense>
            </div>
        );
    }
}

export default withRouter(TApp)

