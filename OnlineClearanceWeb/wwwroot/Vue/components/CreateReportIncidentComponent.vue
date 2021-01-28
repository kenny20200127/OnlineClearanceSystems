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
                            <label class="form-label">Incident</label>
                            <select class="form-control" v-model="postBody.incident" required @change="SelectedValue">
                              <option v-for="subt in incidentList" v-bind:value="subt.incident" v-bind:key="subt.incident"> {{ subt.incident }} </option>
                           </select>
                          
                        </div>
                    </div>
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Code</label>
                            <input type="text" name="incidentCode" class="form-control" v-model="postBody.incidentCode" required :readonly="submitorUpdate == 'Update'" />
                        </div>
                        </div>
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
                            <label class="form-label">Address</label>
                            <input type="text" name="address" class="form-control" v-model="postBody.address"  />
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
                            <label class="form-label">town</label>
                            <input type="text" name="town" class="form-control" v-model="postBody.town"  />
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
                            <label class="form-label">Email</label>
                            <input class="form-control" name="email" v-model="postBody.email" placeholder="" />
                        </div>
                    </div>
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Incident Date</label>
                            <input type="text" name="incidentDate" class="form-control" v-model="postBody.incidentDate"  />
                        </div>
                        </div>
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Incident Type</label>
                            <select class="form-control" v-model="postBody.incidentType" required>
                              <option v-for="subt in incidentTypeList" v-bind:value="subt.name" v-bind:key="subt.name"> {{ subt.description }} </option>
                           </select>
                          
                        </div>
                    </div>
                    
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Incident Location</label>
                            <input type="text" name="incidentLocation" class="form-control" v-model="postBody.incidentLocation"  />
                        </div>
                        </div>
                    
                </div>
               
                <div class="row">
                    <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Reported By</label>
                           <input type="text" name="reportedBy" class="form-control" v-model="postBody.reportedBy"  />

                        </div>
                    </div>
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Incident Nearest Bus Stop</label>
                            <input class="form-control" name="nearestBusStop" v-model="postBody.nearestBusStop" placeholder="" />
                        </div>
                    </div>
                     <div class="col-12 col-xl-6">
                        <div class="form-group">
                            <label class="form-label">Anyother Info</label>
                            <input class="form-control" name="anyotherInfo" v-model="postBody.anyotherInfo" placeholder="" />
                        </div>
                    </div>
                     

                </div>
                <div class="row">
                      <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Upload Photo</label>
                            <input type="file" class="form-control" name="anyotherInfo" />
                        </div>
                    </div>
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
            incidentTypeList:null,
            incidentList:null,
            records:["Yes","No"],
            autoselectenabled:false,
            postBody: {
                incidentCode:'',
                firstName:'',
                OtherName:'',
                address:'',
                tel:'',
                email:'',
                state:'',
                lga:'',
                town:'',
                nearestBusStop:'',
                anyOtherInfo:'',
                incidentType:'',
                incidentDate:'',
                incidentLocation:'',
                reportedBy:'',
                photo1:'',
                photo2:''
         
            }
    
        }
    },
  mounted(){
        //  alert('i am here');
        axios.get(`/api/IncidentType/getAllIncidentTypes`)
        .then(response=>{
            this.incidentTypeList=response.data
        }),
           axios.get(`/api/ReportIncident/getAllReportIncidentbyCase`)
        .then(response=>{
            this.incidentList=response.data

        })
   
    },
    watch:{
         '$store.state.objectToUpdate':function (newVal, oldVal) {
         this.postBody.address = this.$store.state.objectToUpdate.address,
         this.postBody.incidentCode = this.$store.state.objectToUpdate.incidentCode,
         this.postBody.firstName = this.$store.state.objectToUpdate.firstName,
         this.postBody.OtherName = this.$store.state.objectToUpdate.OtherName,
         this.postBody.tel = this.$store.state.objectToUpdate.tel,
         this.postBody.email = this.$store.state.objectToUpdate.email,
         this.postBody.state = this.$store.state.objectToUpdate.state,
          this.postBody.town = this.$store.state.objectToUpdate.town,
         this.postBody.lga = this.$store.state.objectToUpdate.lga,
         this.postBody.nearestBusStop = this.$store.state.objectToUpdate.nearestBusStop,
          this.postBody.anyOtherInfo = this.$store.state.objectToUpdate.anyOtherInfo,
          this.postBody.box = this.$store.state.objectToUpdate.box,
          this.postBody.tel = this.$store.state.objectToUpdate.tel,
          this.postBody.incidentType = this.$store.state.objectToUpdate.incidentType,
          this.postBody.incidentDate = this.$store.state.objectToUpdate.incidentDate,
           this.postBody.incidentLocation = this.$store.state.objectToUpdate.incidentLocation,
          this.postBody.reportedBy = this.$store.state.objectToUpdate.reportedBy

          this.submitorUpdate = 'Update';
               
        }
    },

    methods: {
         SelectedValue(){
      axios.get(`/api/ReportIncident/getAllReportIncidentbyCase/${this.postBody.incident}`)
        .then(response=>{
            this.incidentList=response.data
            this.postBody.incidentCode=response.data.incidentCode
            this.postBody.reportedBy=response.data.reportedBy
            this.postBody.incidentDate=response.data.incidentDate
            this.postBody.reporterNumber=response.data.reporterNumber
            this.postBody.town=response.data.town
            this.postBody.lga=response.data.lga
            this.postBody.state=response.data.state
            this.postBody.incidentLocation=response.data.incidentLocation
            this.postBody.nearestBusStop=response.data.nearestBusStop
            
        })

    },  
        checkForm: function (e) {
            
         if (this.postBody.incidentCode) {
              e.preventDefault();
              this.canProcess = false;
              this.postPost();
          }
          else{

          this.errors = [];
            this.errors.push('ReportIncident Code is Required');
          }
        },
        postPost() {

                if(this.submitorUpdate == 'Submit'){
                    axios.post(`/api/ReportIncident/createReportIncident`, this.postBody )
                        .then(response => {
                            this.responseMessage = response.data.responseDescription;this.canProcess = true;
                            if(response.data.responseCode == '200'){
                                this.postBody.incidentCode=''; 
                                this.postBody.firstName='';
                                this.postBody.address='';
                                this.postBody.OtherName='';
                                this.postBody.tel='';
                                this.postBody.incidentDate='';
                                this.postBody.incidentType='';
                                this.postBody.incidentLocation='';
                                this.postBody.town='';
                                this.postBody.lga='';
                                this.postBody.state='';
                                this.postBody.email='';
                                this.postBody.reportedBy='';
                                this.postBody.anyOtherInfo='';
                                this.postBody.email='';
                                this.postBody.nearestBusStop='';
                                
                                
                            }
                        })
                        .catch(e => {
                            this.errors.push(e)
                        });
                }
                if(this.submitorUpdate == 'Update'){
                    axios.put(`/api/ReportIncident/updateReportIncident`, this.postBody )
                        .then(response => {
                            this.responseMessage = response.data.responseDescription;this.canProcess = true;
                            if(response.data.responseCode == '200'){
                                 this.postBody.incidentCode=''; 
                                this.postBody.firstName='';
                                this.postBody.address='';
                                this.postBody.OtherName='';
                                this.postBody.tel='';
                                this.postBody.incidentDate='';
                                this.postBody.incidentType='';
                                this.postBody.incidentLocation='';
                                this.postBody.town='';
                                this.postBody.lga='';
                                this.postBody.state='';
                                this.postBody.email='';
                                this.postBody.reportedBy='';
                                this.postBody.anyOtherInfo='';
                                this.postBody.email='';
                                this.postBody.nearestBusStop='';
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
                if(objecttoedit.incidentCode){
                   
        this.postBody.address = objecttoedit.address,
         this.postBody.incidentCode =objecttoedit.incidentCode,
         this.postBody.firstName = objecttoedit.firstName,
         this.postBody.OtherName = objecttoedit.OtherName,
         this.postBody.tel = objecttoedit.tel,
         this.postBody.email = objecttoedit.email,
         this.postBody.state = objecttoedit.state,
          this.postBody.town = objecttoedit.town,
         this.postBody.lga = objecttoedit.lga,
         this.postBody.nearestBusStop = objecttoedit.nearestBusStop,
          this.postBody.anyOtherInfo = objecttoedit.anyOtherInfo,
          this.postBody.incidentType = objecttoedit.incidentType,
          this.postBody.incidentDate = objecttoedit.incidentDate,
           this.postBody.incidentLocation = objecttoedit.incidentLocation,
          this.postBody.reportedBy = objecttoedit.reportedBy
        
                }
            }
        }
};
</script>