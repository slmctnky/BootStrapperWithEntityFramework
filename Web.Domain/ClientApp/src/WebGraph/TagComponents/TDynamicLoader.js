import React, { Component } from 'react';


//import GenericWebGraph from "../../WebGraph/GenericWebController/GenericWebGraph"
//import { CommandInterfaces } from "../GenericWebController/CommandInterpreter/cCommandInterpreter"
import { DebugAlert, Class, Interface, Abstract, ObjectTypes, JSTypeOperator } from "../../WebGraph/GenericCoreGraph/ClassFramework/Class"
import cBaseObject from "../GenericCoreGraph/BaseObject/cBaseObject";

//import TObject from "../../WebGraph/TagComponents/TObject"
//import Actions from "../../WebGraph/GenericWebController/ActionGraph/Actions"
//import { CommandIDs } from "../../WebGraph/GenericWebController/CommandInterpreter/CommandIDs/CommandIDs"
//import { WebGraph } from "../../WebGraph/GenericCoreGraph/WebGraph/WebGraph"


var TDynamicLoader = Class(cBaseObject, //TObject,
  {
    ObjectType: ObjectTypes.Get("TDynamicLoader")
    ,
    constructor: function (_Props)
    {
        TDynamicLoader.BaseObject.constructor.call(this, _Props);
        this.InitFirstLoad();
        //GenericWebGraph.Init();
    }
    ,
    InitFirstLoad: function()
    {
        fetch('/webgraph/webapi', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                CID: 1,
                Data: {
                }
            })
        })
            .then(response => response.json())
            .then(response => {
                console.log(response);
            }).catch(err =>
            {
                DebugAlert.Show("hata", err);
            });

    }
    ,
    Destroy: function ()
    {
      TDynamicLoader.BaseObject.Destroy.call(this);
    }
    ,
    render()
    {
      return (
        null
      );
    }
  }, {});

export default TDynamicLoader;
