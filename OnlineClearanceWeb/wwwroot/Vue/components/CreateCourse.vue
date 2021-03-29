<template>
    	<!-- WRAPPER -->
    <div>
        <div v-if="errors" class="has-error"> {{ [errors] }}</div>
        <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
        <form @submit="checkForm" action="/Course/CreateCourse" method="post">
          <div class="p-5" id="vertical-form">
             <div class="preview">
               <div class="grid grid-cols-12 gap-2">
                      <div class="intro-y col-span-12 sm:col-span-6">
                         <div class="mb-2">Code</div>
                              <input type="text" name="name" class="input w-full border col-span-4" v-model="postBody.name" required :readonly="submitorUpdate == 'Update'" />
                        </div>
                      
                    <div class="intro-y col-span-12 sm:col-span-6">
                         <div class="mb-2">Description</div>
                            <input class="input w-full border col-span-4" name="description" v-model="postBody.description" placeholder="Description" />
                        </div>
                    </div>
                    <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">Department </div>
                            <select class="input w-full border col-span-4" v-model="postBody.department" required @change="SelectedValue">
                              <option v-for="dept in DepartmentList" v-bind:value="dept.name" v-bind:key="dept.name"> {{ dept.description }} </option>
                           </select>
                    </div>
                    
                        <div v-if="canProcess" role="group">
                            <button class="button bg-theme-1 text-white mt-5" v-on:click="checkForm" type="submit">{{submitorUpdate}}</button>
                       
                       </div>
                </div>
            </div>
        </form>
    </div>
							
	<!-- END WRAPPER -->
</template>

<script>
	export default {

	data() {
	return {
	errors: null,
	responseMessage:'',
	submitorUpdate : 'Submit',
    DepartmentList:null,
	canProcess : true,
	postBody: {
	name: '',
	description:''
	}

	}
	},
    mounted(){
        //  alert('i am here');
        axios.get(`/api/Department/getAllDepartments`)
        .then(response=>{
            this.DepartmentList=response.data
        })
   
    },
	watch:{
	'$store.state.objectToUpdate':function (newVal, oldVal) {
	this.postBody.name = this.$store.state.objectToUpdate.name,
	this.postBody.description = this.$store.state.objectToUpdate.description
	this.submitorUpdate = 'Update';

	}
	},
	methods: {
	checkForm: function (e) {

	if (this.postBody.name) {
	e.preventDefault();
	this.canProcess = false;
	this.postPost();
	}
	else{

	this.errors = [];
	this.errors.push('Code is Required');
	}
	},
	postPost() {

	if(this.submitorUpdate == 'Submit'){
		alert("i am here")
	axios.post(`/api/Course/createCourse`, this.postBody )
	.then(response => {
	this.responseMessage = response.data.responseDescription;this.canProcess = true;
	if(response.data.responseCode == '200'){
	this.postBody.name = ''; this.postBody.description = '';
	this.$store.state.objectToUpdate = "create";
	}
	})
	.catch(e => {
	this.errors.push(e)
	});
	}
	if(this.submitorUpdate == 'Update'){
	axios.put(`/api/Course/updateCourse`, this.postBody )
	.then(response => {
	this.responseMessage = response.data.responseDescription;this.canProcess = true;
	if(response.data.responseCode == '200'){
	this.submitorUpdate = 'Submit'
	this.postBody.name = ''; this.postBody.description = '';
	this.$store.state.objectToUpdate = "update";
	}
	})
	.catch(e => {
	this.errors.push(e)
	});
	}
	}
	},
	computed: {
	setter(){
	let objecttoedit = this.$store.state.objectToUpdate;
	if(objecttoedit.id){
	this.postBody.name = objecttoedit.name;
	this.postBody.description = objecttoedit.description;
	}
	}
	}
	};
</script>