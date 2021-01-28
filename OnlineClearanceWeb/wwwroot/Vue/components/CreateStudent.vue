<template>
    	<!-- WRAPPER -->
    <div>
        <div v-if="errors" class="has-error"> {{ [errors] }}</div>
        <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
        <form @submit="checkForm"  method="post">
            <div class="card-body">
                <div class="row">
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Student Id</label>
                            <input type="text" name="studentid" class="form-control" v-model="postBody.studentid" required  />
                        </div>
                        </div>
                          <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Department</label>
                            <select class="form-control" v-model="postBody.department" required @change="SelectedValue">
                              <option v-for="dept in departmentList" v-bind:value="dept.name" v-bind:key="dept.name"> {{ dept.description }} </option>
                           </select>
                          
                        </div>
                    </div>
                    <div class="col-12 col-xl-3">
                    <div class="form-group">
                            <label class="form-label">Course</label>
                            <select class="form-control" v-model="postBody.course" required @change="SelectedValue">
                              <option v-for="dept in courseList" v-bind:value="dept.name" v-bind:key="dept.name"> {{ dept.description }} </option>
                           </select>
                          
                        </div>
                    </div>
                </div>
                 <div class="row">
                   <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Graduation Date</label>
                             <vuejsDatepicker type="text" name="graduationdate" class="form-control" v-model="postBody.graduationdate" ></vuejsDatepicker>
                        </div>
                        </div>
                        
                        <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Campus</label>
                            <input type="text" name="campus" class="form-control" v-model="postBody.campus" required  />
                        </div>
                        </div>
                        <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">College</label>
                            <input type="text" name="college" class="form-control" v-model="postBody.college" required  />
                        </div>
                        </div>
                 </div>
                 <div class="row">
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">First Name</label>
                            <input class="form-control" name="firstName" v-model="postBody.firstName" placeholder="" />
                        </div>
                    </div>
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Other Name</label>
                            <input class="form-control" name="otherName" v-model="postBody.otherName" placeholder="" />
                        </div>
                    </div>
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">DOB</label>
                           <vuejsDatepicker type="text" name="dob" class="form-control" v-model="postBody.dob" ></vuejsDatepicker>
                        </div>
                        </div>
                     
                    
                </div>
                 <div class="row">
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Phone Number</label>
                            <input class="form-control" name="tel" v-model="postBody.tel" placeholder="" />
                        </div>
                    </div>
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Local Government</label>
                            <input class="form-control" name="lga" v-model="postBody.lga" placeholder="" />
                        </div>
                    </div>
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">State</label>
                            <input class="form-control" name="state" v-model="postBody.state" placeholder="" />
                        </div>
                    </div>
                     
                </div>
                <div class="row">
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Address</label>
                            <input type="text" name="address" class="form-control" v-model="postBody.address"  />
                        </div>
                        </div>
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Email</label>
                            <input class="form-control" name="email" v-model="postBody.email" placeholder="" />
                        </div>
                    </div>
                    

                </div>
                <div class="row">
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Upload Photo2</label>
                            <input type="file" class="form-control" name="anyotherInfo" />
                        </div>
                    </div>
                    </div>
                <div class="row">
                     
                    <div class="col-12 ">
                        <div class="btn-group mr-2 sw-btn-group-extra" v-if="canProcess" role="group">
                            <button class="btn btn-submit btn-primary" v-on:click="checkForm" type="submit">{{submitorUpdate}}</button>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
							
	<!-- END WRAPPER -->
</template>

<script>
 import vuejsDatepicker from 'vuejs-datepicker';
 export default {
     components:{
        vuejsDatepicker
     },
   
    data() {
        return {
            errors: null,
            responseMessage:'',
            submitorUpdate : 'Submit',
            canProcess : true,
            DepartmentList:null,
            incidentList:null,
            records:["Yes","No"],
            autoselectenabled:false,
            postBody: {
                studentid:'',
                firstName:'',
                OtherName:'',
                address:'',
                tel:'',
                email:'',
                state:'',
                lga:'',
                campus:'',
                course:'',
                department:'',
                college:'',
                graduationdate:'',
                dob:'',
                photo2:''
         
            }
    
        }
    },
  mounted(){
        //  alert('i am here');
        axios.get(`/api/Department/getAllDepartments`)
        .then(response=>{
            this.DepartmentList=response.data
        }),
           axios.get(`/api/course/getAllCourse`)
        .then(response=>{
            this.courseList=response.data

        })
   
    },
    watch:{
         '$store.state.objectToUpdate':function (newVal, oldVal) {
         this.postBody.address = this.$store.state.objectToUpdate.address,
         this.postBody.studentid = this.$store.state.objectToUpdate.studentid,
         this.postBody.firstName = this.$store.state.objectToUpdate.firstName,
         this.postBody.OtherName = this.$store.state.objectToUpdate.OtherName,
         this.postBody.tel = this.$store.state.objectToUpdate.tel,
         this.postBody.email = this.$store.state.objectToUpdate.email,
         this.postBody.state = this.$store.state.objectToUpdate.state,
          this.postBody.campus = this.$store.state.objectToUpdate.campus,
         this.postBody.lga = this.$store.state.objectToUpdate.lga,
         this.postBody.course = this.$store.state.objectToUpdate.course,
          this.postBody.graduationdate = this.$store.state.objectToUpdate.graduationdate,
          this.postBody.dob = this.$store.state.objectToUpdate.dob,
          this.postBody.tel = this.$store.state.objectToUpdate.tel,
          this.postBody.department = this.$store.state.objectToUpdate.department,
          this.postBody.college = this.$store.state.objectToUpdate.college,
          
          this.submitorUpdate = 'Update';
               
        }
    },

    methods: {
         SelectedValue(){
      axios.get(`/api/Student/getAllStudentbyCase/${this.postBody.studentid}`)
        .then(response=>{
            this.studentList=response.data
            this.postBody.firstName=response.data.firstName
            this.postBody.OtherName=response.data.OtherName
            this.postBody.dob=response.data.dob
            this.postBody.campus=response.data.campus
            this.postBody.course=response.data.course
            this.postBody.lga=response.data.lga
            this.postBody.state=response.data.state
            this.postBody.address=response.data.ad
  
            
        })

    },  
        checkForm: function (e) {
            
         if (this.postBody.studentid) {
              e.preventDefault();
              this.canProcess = false;
              this.postPost();
          }
          else{

          this.errors = [];
            this.errors.push('Student ID is Required');
          }
        },
        postPost() {

                if(this.submitorUpdate == 'Submit'){
                    axios.post(`/api/Student/createStudent`, this.postBody )
                        .then(response => {
                            this.responseMessage = response.data.responseDescription;this.canProcess = true;
                            if(response.data.responseCode == '200'){
                                this.postBody.studentid=''; 
                                this.postBody.firstName='';
                                this.postBody.address='';
                                this.postBody.OtherName='';
                                this.postBody.tel='';
                                this.postBody.dob='';
                                this.postBody.department='';
                                this.postBody.college='';
                                this.postBody.course='';
                                this.postBody.lga='';
                                this.postBody.state='';
                                this.postBody.email='';
                                this.postBody.campus='';
                                
                                
                                
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        });
                }
                if(this.submitorUpdate == 'Update'){
                    axios.put(`/api/Student/updateStudent`, this.postBody )
                        .then(response => {
                            this.responseMessage = response.data.responseDescription;this.canProcess = true;
                            if(response.data.responseCode == '200'){
                                  this.postBody.studentid=''; 
                                this.postBody.firstName='';
                                this.postBody.address='';
                                this.postBody.OtherName='';
                                this.postBody.tel='';
                                this.postBody.dob='';
                                this.postBody.department='';
                                this.postBody.college='';
                                this.postBody.course='';
                                this.postBody.lga='';
                                this.postBody.state='';
                                this.postBody.email='';
                                this.postBody.campus='';
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
                if(objecttoedit.studentid){
                   
        this.postBody.address = objecttoedit.address,
         this.postBody.studentid =objecttoedit.studentid,
         this.postBody.firstName = objecttoedit.firstName,
         this.postBody.OtherName = objecttoedit.OtherName,
         this.postBody.tel = objecttoedit.tel,
         this.postBody.email = objecttoedit.email,
         this.postBody.state = objecttoedit.state,
          this.postBody.town = objecttoedit.town,
         this.postBody.lga = objecttoedit.lga,
         this.postBody.college = objecttoedit.college,
          this.postBody.campus = objecttoedit.campus,
          this.postBody.department = objecttoedit.department,
          this.postBody.course = objecttoedit.course
                 
                }
            }
        }
};
</script>