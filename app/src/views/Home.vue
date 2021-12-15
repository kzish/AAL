<template>
 <div>
   <div class="home-banner">
     <center>
        <h4>Online English tutors & teachers for private lessons</h4>
        <p>
          Looking for an online tutor? Adeyemi Academy is the leading online language learning platform in the country. You can choose from 12402+ tutors. Book a lesson with a private tutor today and start learning.
        </p>
     </center>
   </div>
   <div class="tutor-list">
     <div class="row">
       <div class="col-md-12" v-for="tutor in tutors" :key="tutor.Id">
         <div class="tutor-profile-item">
           <img :src="globals.api_end_point+'/Tutors/GetImage/'+tutor.MTutor.ImageUrl" class="rounded float-left" alt="...">
              {{tutor.MTutor.Firstname}} {{tutor.MTutor.Surname}}
         </div>
       </div>
     </div>
   </div>
 </div>
</template>

<script>
import {globals} from '@/assets/js/globals.js'
import axios from "axios";

export default {
  name: 'Home',
  components: {
  },
  data(){
    return {
      tutors: null,
      globals: globals,
    }
  },
  mounted(){
     this.fetchTutors();
  },
  methods: {
    fetchTutors(){
      axios.get(globals.api_end_point+"/Tutors/FetchTutors")
          .then(response => {
            if(response.data.res === "ok") {
              this.tutors = response.data.data;
            } else {
              alert(response.data.msg);
            }
          })
          .catch(error => console.log(error))
          .finally(() => {})
    },
  }
}
</script>
