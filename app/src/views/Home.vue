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

  <div class="row">
    <div class="col-md-12">
      <div class="top-home-search">
        <center>
          <div class="input-group">
              <input type="text" :value="this.search_term" class="form-control top-home-search-text" placeholder="Type Course or topic">
               <div class="input-group-append">
                <button type="button" @click="this.clearSearch();" class="btn btn-outline-danger top-home-search-text">
                  X<span class="glyphicon glyphicon-align-left" aria-hidden="true"></span>
                </button>
              </div>
              <div class="input-group-append">
                <button type="button" class="btn btn-primary top-home-search-text">
                  Search Course<span class="glyphicon glyphicon-align-left" aria-hidden="true"></span>
                </button>
              </div>
          </div>
        </center>
        <div class="row">
          <div class="col-md-12">
            country filter, language filter, availability filter drop downs
          </div>
        </div>
      </div>
    </div>
  </div>


   <div class="tutor-list">
     <div class="row">
       <div class="col-md-12 tutor-profile-item-contianer" v-for="tutor in tutors" :key="tutor.aspnetUserId">
         <div class="tutor-profile-item">
           <div class="row">
             <div class="col-md-2">
               <table>
                 <tr>
                   <td>
                     <img v-if="tutor.imageUrl!=='' && tutor.imageUrl!== null" :src="globals.api_end_point+'/Tutors/GetImage/'+tutor.imageUrl" class="rounded float-left tutor-home-img" alt="...">
                     <img v-if="tutor.imageUrl=='' || tutor.imageUrl==null" src="/assets/img/place-holder-profile-image.png" class="rounded float-left tutor-home-img" alt="...">
                   </td>
                  </tr>
                  <tr>
                    <td>
                      {{tutor.firstname}} {{tutor.surname}}
                    </td>
                  </tr>
                  <tr>
                    <td>tutor rating</td>
                  </tr>
               </table>
             </div>
             <div class="col-md-10">
               <table>
                 <tr>
                   <td>{{tutor.coutryName}}:flag icon</td>
                 </tr>
                 <tr>
                   <td>
                       <span v-for="language in tutor.languages" :key="language">{{language.trim()}}, </span>
                   </td>
                 </tr>
                 <tr>
                   <td>
                       <span v-for="course in tutor.courses" :key="course">{{course.trim().replace(" - " + tutor.email, "")}},</span>
                   </td>
                 </tr>
                 <tr>
                   <td><i><b>{{tutor.about.substring(0,100)}}...</b></i></td>
                 </tr>
                 <tr>
                   <td><a href="javascript:void(0);">View more</a></td>
                 </tr>
               </table>
             </div>
           </div>
           <div class="row">
             <div class="col-md-12">
               <div class="contact-tutor-icons">
                  whatsapp, email, call
               </div>
             </div>
           </div>
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
      search_term: 'hassan',
    }
  },
  mounted(){
     this.fetchTutors();
  },
  methods: {
    clearSearch() {
      this.search_term = 'imam';
      // alert('called');
      // this.fetchTutors();
    },
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
