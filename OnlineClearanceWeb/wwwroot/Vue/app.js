window.Vue = require('vue')
window.axios = require('axios')
import store from './store'

import CreateStudent from './components/CreateStudent.vue';
import ViewStudent from './components/ViewStudent.vue';
import CreateDepartment from './components/CreateDepartment.vue';
import ViewDepartment from './components/ViewDepartment.vue';
import ViewCourse from './components/ViewCourse.vue';
import CreateCourse from './components/CreateCourse.vue';

const files = require.context('./', true, /\.vue$/i)
files.keys().map(key => Vue.component(key.split('/').pop().split('.')[0], files(key).default));

Vue.component('create-student', CreateStudent);
Vue.component('view-student',ViewStudent);
Vue.component('create-department',CreateDepartment);
Vue.component('view-department',ViewDepartment);
Vue.component('view-course',ViewCourse);
Vue.component('create-course',CreateCourse);
 
const app = new Vue({
    el: "#app",
    store
});