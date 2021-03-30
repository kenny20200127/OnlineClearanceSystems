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
                        <!-- <th>Department</th> -->
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(Course,index) in CourseList" :key="index">
                        <td>{{ Course.name }}</td>
                        <td>{{ Course.description }}</td>
                        <!-- <td>{{ Course.departmentcode }}</td> -->
                       
                       
                        <td>
                            <button type="button" class="button bg-theme-1 text-white mt-5" @click="processRetrieve(Course)">Edit</button>
                            <button type="button" class="button bg-theme-1 text-white mt-5" @click="processDelete(Course.id)">Delete</button></td>
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
                    CourseList: null,
                    responseMessage:''
                };
            },
        created() {
            this.$store.state.objectToUpdate = null;
        },
    watch:{
         '$store.state.objectToUpdate':function (newVal, oldVal) {
            this.getAllCourses();
            this.processDelete();
        }
    },
    mounted () {
        this.getAllCourses();
        this.processDelete();
     },
     methods: {
 
        processRetrieve : function (Course) {
            this.$store.state.objectToUpdate = Course;
         },
         processDelete: function (id) {

             axios.get(`/api/Course/RemoveCourse/${id}`)
                 .then(response => {
                     if (response.data.responseCode == '200') {
                         alert("balance sheet successfully deleted");
                         this.getAllCourses();
                     }
                 }).catch(e => {
                            this.errors.push(e)
                        });

         },
         getAllCourses: function () {
             axios
            .get('/api/Course/getAllCourses')
            .then(response => (this.CourseList = response.data))
         }
    }  
};
</script>