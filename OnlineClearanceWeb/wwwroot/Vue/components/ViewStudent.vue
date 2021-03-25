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
                    <tr v-for="(incident,index) in StudentsList" :key="index">
                        <td>{{ incident.incidentCode }}</td>
                        <td>{{ incident.firstName }}  {{ incident.otherName }}</td>
                        <td>{{ incident.address }}</td>
                        <td>{{ incident.incidentDate }}</td>
                        <td>{{ incident.Department }}</td>
                        
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
                    StudentsList: null,
                    responseMessage:''
                };
            },
        created() {
            this.$store.state.objectToUpdate = null;
        },
    watch:{
         '$store.state.objectToUpdate':function (newVal, oldVal) {
            this.getAllStudents();
            //this.processDelete();
        }
    },
    mounted () {
        this.getAllStudents();
       // this.processDelete();
     },
     methods: {
 
        processRetrieve : function (incident) {
            this.$store.state.objectToUpdate = incident;
         },
         processDelete: function (id) {

             axios.get(`/api/Students/RemoveStudents/${id}`)
                 .then(response => {
                     if (response.data.responseCode == '200') {
                         alert("Students successfully deleted");
                         this.getAllStudents();
                     }
                 }).catch(e => {
                            this.errors.push(e)
                        });

         },
         getAllStudents: function () {
             axios
            .get('/api/Students/getAllStudents')
            .then(response => (this.StudentsList = response.data))
         }
    }
    
};
</script>