window.Vue = require('vue')
window.axios = require('axios')
import store from './store'

import CreateReportIncidentComponent from './components/CreateReportIncidentComponent.vue';
import ViewReportIncidentComponent from './components/ViewReportIncidentComponent.vue';
import CreateIncidentType from './components/CreateIncidentType.vue';
import ViewIncidentType from './components/ViewIncidentType.vue';

const files = require.context('./', true, /\.vue$/i)
files.keys().map(key => Vue.component(key.split('/').pop().split('.')[0], files(key).default));

Vue.component('create-report-Iicident-component', CreateReportIncidentComponent);
Vue.component('view-report-incident-component',ViewReportIncidentComponent);
Vue.component('create-incident-type',CreateIncidentType);
Vue.component('view-incident-type',ViewIncidentType);
 
const app = new Vue({
    el: "#app",
    store
});