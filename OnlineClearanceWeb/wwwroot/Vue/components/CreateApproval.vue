<template>
    	<!-- WRAPPER -->
    <div>
        <div v-if="errors" class="has-error"> {{ [errors] }}</div>
        <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
        <form @submit="checkForm"  method="post">
                        <!-- END: Top Bar -->
                <!-- <div class="intro-y flex items-center mt-8">
                    <h2 class="text-lg font-medium mr-auto">
                        Profile
                    </h2>
                </div> -->
                <!-- BEGIN: Profile Info -->
                <!-- <div class="intro-y box px-5 pt-5 mt-5">
                    <div class="flex flex-col lg:flex-row border-b border-gray-200 dark:border-dark-5 pb-5 -mx-5">
                        <div class="flex flex-1 px-5 items-center justify-center lg:justify-start">
                            <div class="w-20 h-20 sm:w-24 sm:h-24 flex-none lg:w-32 lg:h-32 image-fit relative">
                                <!-- <img alt="Midone Tailwind HTML Admin Template" class="rounded-full" src="dist/images/profile-10.jpg"> -->
                                <!-- <div class="absolute mb-1 mr-1 flex items-center justify-center bottom-0 right-0 bg-theme-1 rounded-full p-2"> <i class="w-4 h-4 text-white" data-feather="camera"></i> </div>
                            </div>
                            <div class="ml-5">
                                <div class="w-24 sm:w-40 truncate sm:whitespace-normal font-medium text-lg"> {{postBody.firstName +" "+ postBody.otherName}}   
                                </div>
                                <div class="text-gray-600">{{postBody.department}}</div>
                            </div>
                        </div>
                        <div class="flex mt-6 lg:mt-0 items-center lg:items-start flex-1 flex-col justify-center text-gray-600 dark:text-gray-300 px-5 border-l border-r border-gray-200 dark:border-dark-5 border-t lg:border-t-0 pt-5 lg:pt-0">
                            <div class="truncate sm:whitespace-normal flex items-center"> <i data-feather="mail" class="w-4 h-4 mr-2"></i> {{postBody.email}} </div>
                            <div class="truncate sm:whitespace-normal flex items-center mt-3"> <i data-feather="instagram" class="w-4 h-4 mr-2"></i> {{postBody.department}}</div>
                            <div class="truncate sm:whitespace-normal flex items-center mt-3"> <i data-feather="twitter" class="w-4 h-4 mr-2"></i> {{postBody.Course}} </div>
                        </div>
                   
                    </div>
                 </div>  -->
                <!-- END: Profile Info -->

        
            <div class="p-5" id="vertical-form">
        <div class="preview">
               <div class="grid grid-cols-12 gap-2">
                      <div class="intro-y col-span-12 sm:col-span-4">
                             <div class="mb-2">Student Id </div>
                            <input type="text" name="studentid" class="input w-full border col-span-4" v-model="postBody.studentid" required  />
                        </div>
                        <div class="intro-y col-span-12 sm:col-span-4">
                       
                             <div class="mb-2">Department </div>
                            <select class="input w-full border col-span-4" v-model="postBody.department" name="department" required @change="coursechange">
                              <option v-for="dept in DepartmentList" v-bind:value="dept.name" v-bind:key="dept.name"> {{ dept.description }} </option>
                           </select>
                    </div>
                     <div class="intro-y col-span-12 sm:col-span-4">
                   
                             <div class="mb-2">Course </div>
                            <select class="input w-full border col-span-4" v-model="postBody.course" name="course" required @change="SelectedValue">
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
             <!-- <div class="grid grid-cols-12 gap-2">
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
                </div> -->
            <div class="grid grid-cols-12 gap-2">
                <div class="intro-y col-span-12 sm:col-span-4">
                                <div class="mb-2">Status</div>
                                <select class="input w-full border flex-1" v-model="postBody.status" name="status" placeholder="" required>
                                    <option v-for="st in statusList" v-bind:value="st.value" v-bind:key="st.value"> {{ st.text }} </option>
                                </select>
                            </div>
            </div>
             <div class="grid grid-cols-12 gap-2">
                      <div class="intro-y col-span-12 sm:col-span-4">
                          <div class="mb-2">HOD Approval </div>
                            <input type="text" class="input w-full border col-span-4" name="approvedbyHOD" v-model="postBody.approvedbyHOD" />
                        </div>
                        <div class="intro-y col-span-12 sm:col-span-4">
                                <div class="mb-2">HOD Approval Date</div>
                                <vuejsDatepicker v-model="postBody.approvedDateHOD" input-class="input w-full border flex-1" name="approvedDateHOD" aria-placeholder=""></vuejsDatepicker>
                            </div>
                      <div class="intro-y col-span-12 sm:col-span-4">
                          <div class="mb-2"> HOD Remark </div>
                            <input type="text" class="input w-full border col-span-4" name="hodremark" v-model="postBody.hodremark" />
                        </div>
                   
                </div>
                     <div class="grid grid-cols-12 gap-2">
                      <div class="intro-y col-span-12 sm:col-span-4">
                          <div class="mb-2">School Library Approval </div>
                            <input type="text" class="input w-full border col-span-4" name="approvedbyLIB" v-model="postBody.approvedbyLIB" />
                        </div>
                        <div class="intro-y col-span-12 sm:col-span-4">
                                <div class="mb-2">Library Approval Date</div>
                                <vuejsDatepicker v-model="postBody.approvedDateLIB" input-class="input w-full border flex-1" name="approvedDateLIB" aria-placeholder=""></vuejsDatepicker>
                            </div>
                             <div class="intro-y col-span-12 sm:col-span-4">
                          <div class="mb-2"> School Library Remark </div>
                            <input type="text" class="input w-full border col-span-4" name="libremark" v-model="postBody.libremark" />
                        </div>
                   
                    </div>
                     <div class="grid grid-cols-12 gap-2">
                      <div class="intro-y col-span-12 sm:col-span-4">
                          <div class="mb-2"> School Admin Approval </div>
                            <input type="text" class="input w-full border col-span-4" name="approvedbyAdmin" v-model="postBody.approvedbyAdmin" />
                        </div>
                          <div class="intro-y col-span-12 sm:col-span-4">
                                <div class="mb-2">Admin Approval Date</div>
                                <vuejsDatepicker v-model="postBody.approvedDateAdmin" input-class="input w-full border flex-1" name="approvedDateAdmin" aria-placeholder=""></vuejsDatepicker>
                            </div>
                        <div class="intro-y col-span-12 sm:col-span-4">
                          <div class="mb-2"> School Admin Remark </div>
                            <input type="text" class="input w-full border col-span-4" name="adminremark" v-model="postBody.adminremark" />
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
            statusList:null,
            records:["Yes","No"],
            autoselectenabled:false,
            postBody: {
                studentid:'',
                firstName:'',
                OtherName:'',
                address:'',
                tel:'',
                email:'',
                state:null,
                lga:'',
                campus:'',
                course:null,
                department:'',
                college:'',
                graduationdate:null,
                dob:null,
                gpa:'',
                status:null,
                approvedbyHOD:'',
                approvedbyLIB:'',
                approvedbyAdmin:'',
                approvedDateHOD:null,
                approvedDateLIB:null,
                approvedDateAdmin:null,
                adminremark:'',
                libremark:'',
                hodremark:'',
                photo2:''
         
            },
             statusList: [
            { value: '', text: 'Status' },
            { value: 'Approve', text: 'Approve' },
            { value: 'Decline', text: 'Decline' },
           
            ],
    
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
         this.postBody.studentid = this.$store.state.objectToUpdate.studentId,
         this.postBody.firstName = this.$store.state.objectToUpdate.firstName,
         this.postBody.OtherName = this.$store.state.objectToUpdate.otherNames,
         this.postBody.tel = this.$store.state.objectToUpdate.tel,
         this.postBody.email = this.$store.state.objectToUpdate.email,
         this.postBody.state = this.$store.state.objectToUpdate.state,
          this.postBody.campus = this.$store.state.objectToUpdate.campus,
         this.postBody.lga = this.$store.state.objectToUpdate.lga,
         this.postBody.course = this.$store.state.objectToUpdate.courseProgram,
          this.postBody.graduationdate = this.$store.state.objectToUpdate.graduatedDate,
          this.postBody.dob = this.$store.state.objectToUpdate.dob,
          this.postBody.tel = this.$store.state.objectToUpdate.tel,
          this.postBody.department = this.$store.state.objectToUpdate.department,
          this.postBody.college = this.$store.state.objectToUpdate.college,
          this.postBody.approvedbyHOD = this.$store.state.objectToUpdate.approvedbyHOD,
          this.postBody.approvedDateHOD = this.$store.state.objectToUpdate.approvedDateHOD,
           this.postBody.hodremark = this.$store.state.objectToUpdate.hodremark,
          this.postBody.approvedbyAdmin = this.$store.state.objectToUpdate.approvedbyAdmin,
          this.postBody.approvedDateAdmin = this.$store.state.objectToUpdate.approvedDateAdmin,
          this.postBody.adminremark = this.$store.state.objectToUpdate.adminremark,

          this.postBody.approvedbyLIB = this.$store.state.objectToUpdate.approvedbyLIB,
          this.postBody.approvedDateLIB = this.$store.state.objectToUpdate.approvedDateLIB,
          this.postBody.libremark = this.$store.state.objectToUpdate.libremark,
       
          
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