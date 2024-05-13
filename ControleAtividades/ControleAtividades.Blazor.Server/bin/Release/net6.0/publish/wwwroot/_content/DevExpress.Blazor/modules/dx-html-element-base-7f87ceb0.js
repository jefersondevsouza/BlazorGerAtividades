import{D as e}from"./data-qa-utils-8be7c726.js";import{H as t,D as n,L as i}from"./dx-html-element-pointer-events-helper-0f2b6602.js";const o=document.createElement("template");o.innerHTML="<slot />";class s extends HTMLElement{constructor(){super(),this._handlePointerEventsMode=t.None,this._isInitialized=!1,this.pointerEventsHelper=new n(this),this.contentChangedObserver=null,this.prepareComponent()}get isInitialized(){return this._isInitialized}get useShadowDom(){return!0}connectedCallback(){!this.useShadowDom&&this.childElementCount>0&&this.componentContentChanged(),this.pointerEventsHelper.initialize(),e.setLoaded(this)}disconnectedCallback(){e.removeLoaded(this),this.pointerEventsHelper.dispose(),this.disposeComponent()}initializeComponent(){}afterInitialize(){}disposeComponent(){var e;null===(e=this.contentChangedObserver)||void 0===e||e.disconnect()}getContentTemplate(){return o}componentContentChanged(){this.initializeComponent(),this._isInitialized=!0,this.afterInitialize()}prepareComponent(){this.useShadowDom?this.prepareShadowDom():(this.contentChangedObserver=new MutationObserver(this.componentContentChanged.bind(this)),this.contentChangedObserver.observe(this,{childList:!0}))}prepareShadowDom(){const e=this.attachShadow({mode:"open"});e.appendChild(this.getContentTemplate().content.cloneNode(!0));e.querySelector("slot").addEventListener("slotchange",this.componentContentChanged.bind(this))}get handlePointerEventsMode(){return this._handlePointerEventsMode}set handlePointerEventsMode(e){this._handlePointerEventsMode=e}get handlePointerEventsTarget(){return this}get handlePointerEventsDelay(){return i}}export{s as D};
