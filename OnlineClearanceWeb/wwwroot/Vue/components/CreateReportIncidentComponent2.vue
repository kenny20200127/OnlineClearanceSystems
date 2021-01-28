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
                            <label class="form-label">Name</label>
                            <input class="form-control" name="reportedBy" v-model="postBody.reportedBy" placeholder="" />
                        </div>
                    </div>
                   
                     
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
                </div>
                <div class="row">
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
                  
                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Incident Date</label>
                            <vuejsDatepicker type="text" name="incidentDate" class="form-control" v-model="postBody.incidentDate" ></vuejsDatepicker>
                        </div>
                        </div>
                    
                </div>
               
                <div class="row">
                      <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Incident Location</label>
                            <input type="text" name="incidentLocation" class="form-control" v-model="postBody.incidentLocation"  />
                        </div>
                        </div>

                     <div class="col-12 col-xl-3">
                        <div class="form-group">
                            <label class="form-label">Incident Nearest Bus Stop</label>
                            <input class="form-control" name="nearestBusStop" v-model="postBody.nearestBusStop" placeholder="" />
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
            records:["Yes","No"],
            autoselectenabled:false,
            postBody: {
                incidentCode:'',
                reportedBy:'',
                tel:'',
                state:'',
                lga:'',
                town:'',
                nearestBusStop:'',
                incidentType:'',
                incidentDate:'',
                incidentLocation:'',

         
            }
    
        }
    },
 

    methods: {
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
                                this.postBody.tel='';
                                this.postBody.incidentDate='';
                                this.postBody.incidentType='';
                                this.postBody.incidentLocation='';
                                this.postBody.town='';
                                this.postBody.lga='';
                                this.postBody.state='';
                                this.postBody.email='';
                                this.postBody.nearestBusStop='';
                                 this.postBody.reportedBy='';
                                
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