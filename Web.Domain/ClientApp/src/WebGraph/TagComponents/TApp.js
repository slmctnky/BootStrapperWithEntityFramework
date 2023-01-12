import React, { Component } from "react";
import withRouter from "./Utilities/withRouter";
import TLoading from "./Utilities/TLoading";
import { ThemeProvider } from "@mui/material/styles";
import { WebGraph } from "../GenericCoreGraph/WebGraph/WebGraph";

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
    }


    GetTheme() {
        return window.Themes.DefaultTheme;
    }

    render() {
        return (
            <div style={{ fontFamily: "Montserrat" }}>
                <React.Suspense fallback={<div class="loader"></div>}>
                    <ThemeProvider theme={this.GetTheme()}>
                        <TDynamicLoader getInnerChilds={() => {
                            return <Button variant="contained">{window.GenericWebGraph.Managers.LanguageManager.ActiveLanguage.Hi}</Button>
                        }} />
                    </ThemeProvider>
                </React.Suspense>
            </div>
        );
    }
}

export default withRouter(TApp)

