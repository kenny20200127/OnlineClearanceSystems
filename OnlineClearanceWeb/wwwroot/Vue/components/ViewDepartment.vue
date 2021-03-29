<template>
    	<!-- WRAPPER -->
    <div>
        
        <div class="card-body">
            <div v-if="responseMessage" class="has-error"> {{ responseMessage }}</div>
            <table id="datatables-buttons" class="table table-striped table-bordered table-hover" style="width:100%">
                <thead>
                    <tr>
                        <th>Code</th>
                        <th>Description</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(Department,index) in DepartmentList" :key="index">
                        <td>{{ Department.name }}</td>
                        <td>{{ Department.description }}</td>
                       
                       
                        <td>
                            <button type="button" class="button bg-theme-1 text-white mt-5" @click="processRetrieve(Department)">Edit</button>
                            <button type="button" class="button bg-theme-1 text-white mt-5" @click="processDelete(Department.id)">Delete</button></td>
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
                    DepartmentList: null,
                    responseMessage:''
                };
            },
        created() {
            this.$store.state.objectToUpdate = null;
        },
    watch:{
         '$store.state.objectToUpdate':function (newVal, oldVal) {
            this.getAllDepartments();
            this.processDelete();
        }
    },
    mounted () {
        this.getAllDepartments();
        this.processDelete();
     },
     methods: {
 
        processRetrieve : function (Department) {
            this.$store.state.objectToUpdate = Department;
         },
         processDelete: function (id) {

             axios.get(`/api/Department/RemoveDepartment/${id}`)
                 .then(response => {
                     if (response.data.responseCode == '200') {
                         alert("balance sheet successfully deleted");
                         this.getAllDepartments();
                     }
                 }).catch(e => {
                            this.errors.push(e)
                        });

         },
         getAllDepartments: function () {
             axios
            .get('/api/Department/getAllDepartments')
            .then(response => (this.DepartmentList = response.data))
         }
    }  
};
</script>