<template>
    	<!-- WRAPPER -->
    <div>
        
        <div class="card-body">
            <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
            <table id="datatables-buttons" class="table table-striped" style="width:100%">
                <thead>
                    <tr>
                        <th>Incident Code</th>
                        <th>Name</th>
                        <th>Address</th>
                        <th>Incident Date</th>
                        <th>Incident Type</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(incident,index) in ReportIncidentList" :key="index">
                        <td>{{ incident.incidentCode }}</td>
                        <td>{{ incident.firstName }}  {{ incident.otherName }}</td>
                        <td>{{ incident.address }}</td>
                        <td>{{ incident.incidentDate }}</td>
                        <td>{{ incident.incidentType }}</td>
                        
                        <td>
                            <button type="button" class="btn btn-submit btn-primary" @click="processRetrieve(incident)">Edit</button>
                            <button type="button" class="btn btn-submit btn-primary" @click="processDelete(incident.id)">Delete</button>
                        </td>
                    </tr>
                </tbody>
              
            </table>
    </div>

    </div>

        <!-- END WRAPPER -->
</template>

<script>
export default { 
    
            data() {
                return {
                    ReportIncidentList: null,
                    responseMessage:''
                };
            },
        created() {
            this.$store.state.objectToUpdate = null;
        },
    watch:{
         '$store.state.objectToUpdate':function (newVal, oldVal) {
            this.getAllReportIncident();
            //this.processDelete();
        }
    },
    mounted () {
        this.getAllReportIncident();
       // this.processDelete();
     },
     methods: {
 
        processRetrieve : function (incident) {
            this.$store.state.objectToUpdate = incident;
         },
         processDelete: function (id) {

             axios.get(`/api/ReportIncident/RemoveReportIncident/${id}`)
                 .then(response => {
                     if (response.data.responseCode == '200') {
                         alert("ReportIncident successfully deleted");
                         this.getAllReportIncident();
                     }
                 }).catch(e => {
                            this.errors.push(e)
                        });

         },
         getAllReportIncident: function () {
             axios
            .get('/api/ReportIncident/getAllReportIncident')
            .then(response => (this.ReportIncidentList = response.data))
         }
    }
    
};
</script>