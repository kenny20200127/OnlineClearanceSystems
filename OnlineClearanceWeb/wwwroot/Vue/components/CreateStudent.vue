<template>
    	<!-- WRAPPER -->
    <div>
        <div v-if="errors" class="has-error"> {{ [errors] }}</div>
        <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
        <form @submit="checkForm"  method="post">
            <div class="p-5" id="vertical-form">
        <div class="preview">
               <div class="grid grid-cols-12 gap-2">
                      <div class="intro-y col-span-12 sm:col-span-4">
                             <div class="mb-2">Student Id </div>
                            <input type="text" name="studentid" class="input w-full border col-span-4" v-model="postBody.studentid" required  />
                        </div>
                        <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">Department </div>
                            <select class="input w-full border col-span-4" v-model="postBody.department" required @change="coursechange">
                              <option v-for="dept in DepartmentList" v-bind:value="dept.name" v-bind:key="dept.name"> {{ dept.description }} </option>
                           </select>
                    </div>
                     <div class="intro-y col-span-12 sm:col-span-4">
                   
                             <div class="mb-2">Course </div>
                            <select class="input w-full border col-span-4" v-model="postBody.course" required @change="SelectedValue">
                              <option v-for="dept in courseList" v-bind:value="dept.name" v-bind:key="dept.name"> {{ dept.description }} </option>
                           </select>
                          
                        </div>
                  
                </div>
           <div class="grid grid-cols-12 gap-2">
                    <div class="intro-y col-span-12 sm:col-span-4">
                             <div class="mb-2">Graduation Date </div>
                             <vuejsDatepicker type="text" name="graduationdate" class="input w-full border col-span-4" v-model="postBody.graduationdate" ></vuejsDatepicker>
                        </div>
                         <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">Campus </div>
                            <input type="text" name="campus" class="input w-full border col-span-4" v-model="postBody.campus" required  />
                        </div>
                        
                         <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">College </div>
                            <input type="text" name="college" class="input w-full border col-span-4" v-model="postBody.college" required  />
                        </div>
                       
                 </div>
             <div class="grid grid-cols-12 gap-2">
                     <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">First Name </div>
                            <input class="input w-full border col-span-4" name="firstName" v-model="postBody.firstName" placeholder="" />
                        </div>
                   
                     <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">Other Name </div>
                            <input class="input w-full border col-span-4" name="otherName" v-model="postBody.otherName" placeholder="" />
                        </div>
                
                     <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">DOB </div>
                           <vuejsDatepicker type="text" name="dob" class="input w-full border col-span-4" v-model="postBody.dob" ></vuejsDatepicker>
                        </div>
                </div>
            <div class="grid grid-cols-12 gap-2">
                      <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">Phone Number </div>
                            <input class="input w-full border col-span-4" name="tel" v-model="postBody.tel" placeholder="" />
                        </div>
                    
                    <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">State </div>
                            <select class="input w-full border col-span-4" v-model="postBody.state" required @change="lgachange">
                              <option v-for="st in StateList" v-bind:value="st.name" v-bind:key="st.name"> {{ st.description }} </option>
                           </select>
                    </div>
                        <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">Local Government </div>
                            <select class="input w-full border col-span-4" v-model="postBody.lga" required @change="SelectedValue">
                              <option v-for="lg in LocalGovtList" v-bind:value="lg.name" v-bind:key="lg.name"> {{ lg.description }} </option>
                           </select>
                    </div>
                   
                                   
                     
                </div>
            <div class="grid grid-cols-12 gap-2">
                     <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">Address </div>
                            <input type="text" name="address" class="input w-full border col-span-4" v-model="postBody.address"  />
                        </div>
                     
                     <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">Email </div>
                            <input class="input w-full border col-span-4" name="email" v-model="postBody.email" placeholder="" />
                        </div>
                </div>
             <div class="grid grid-cols-12 gap-2">
                      <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">Upload Photo2 </div>
                            <input type="file" class="input w-full border col-span-4" name="anyotherInfo" />
                        </div>
                   
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
            CourseList:null,
            StateList:null,
            LocalGovtList:null,
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
           axios.get(`/api/States/getAllStatess`)
        .then(response=>{
            this.StateList=response.data

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
        coursechange(){
            alert(this.postBody.department);
             axios.get(`/api/course/getCourseByCode/${this.postBody.department}`)
        .then(response=>{
            this.courseList=response.data

        })
        },
        lgachange(){
            alert(this.postBody.state);
             axios.get(`/api/LocalGovernment/getAllLocalGovernmentByState/${this.postBody.state}`)
        .then(response=>{
            this.LocalGovtList=response.data

        })
        },
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