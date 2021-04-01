<template>
    	<!-- WRAPPER -->
    <div>
        
        <div class="card-body">
            <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
            <table id="datatables-buttons" class="table table-striped table-bordered table-hover" style="width:100%">
                <thead>
                    <tr>
                        <th>Student Id</th>
                        <th>Name</th>
                        <th>Address</th>
                        <th>Graduation Date</th>
                        <th>Department</th>
                        <th>Course</th>
                        <th>GPA</th>
                        <th>approvedDate Date</th>
                        <th>Remark</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(incident,index) in StudentsList" :key="index">
                        <td>{{ incident.studentId }}</td>
                        <td>{{ incident.firstName }}  {{ incident.otherNames }}</td>
                        <td>{{ incident.address }}</td>
                        <td>{{ incident.graduationDate }}</td>
                        <td>{{ incident.department }}</td>
                        <td>{{ incident.course }}</td>
                        <td>{{ incident.gpa }}</td>
                        <td>{{ incident.approvedDate }}</td>
                        <td>{{ incident.remark }}</td>
                        
                        <!-- <td>
                            <button type="button" class="button bg-theme-1 text-white mt-5" @click="processRetrieve(incident)">Approve</button>
                            <button type="button" class="button bg-theme-1 text-white mt-5" @click="processDelete(incident.id)">Decline </button>
                        </td> -->
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
            .get('/api/Student/getAllApproveStudent')
            .then(response => (this.StudentsList = response.data))
         }
    }
    
};
</script>