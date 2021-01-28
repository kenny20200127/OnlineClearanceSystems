<template>
    	<!-- WRAPPER -->
    <div>
        
        <div class="card-body">
            <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
            <table id="datatables-buttons" class="table table-striped" style="width:100%">
                <thead>
                    <tr>
                        <th>Code</th>
                        <th>Description</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(IncidentType,index) in IncidentTypeList" :key="index">
                        <td>{{ IncidentType.name }}</td>
                        <td>{{ IncidentType.description }}</td>
                       
                       
                        <td>
                            <button type="button" class="btn btn-submit btn-primary" @click="processRetrieve(IncidentType)">Edit</button>
                            <button type="button" class="btn btn-submit btn-primary" @click="processDelete(IncidentType.id)">Delete</button></td>
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
                    IncidentTypeList: null,
                    responseMessage:''
                };
            },
        created() {
            this.$store.state.objectToUpdate = null;
        },
    watch:{
         '$store.state.objectToUpdate':function (newVal, oldVal) {
            this.getAllIncidentTypes();
            this.processDelete();
        }
    },
    mounted () {
        this.getAllIncidentTypes();
        this.processDelete();
     },
     methods: {
 
        processRetrieve : function (IncidentType) {
            this.$store.state.objectToUpdate = IncidentType;
         },
         processDelete: function (id) {

             axios.get(`/api/IncidentType/RemoveIncidentType/${id}`)
                 .then(response => {
                     if (response.data.responseCode == '200') {
                         alert("balance sheet successfully deleted");
                         this.getAllIncidentTypes();
                     }
                 }).catch(e => {
                            this.errors.push(e)
                        });

         },
         getAllIncidentTypes: function () {
             axios
            .get('/api/IncidentType/getAllIncidentTypes')
            .then(response => (this.IncidentTypeList = response.data))
         }
    }  
};
</script>