<template>
  <div class="tutor-profile-item tutor-profile-item-information"
   v-bind:class="{ 'tutor-profile-item-border' : border }"
   v-if="selectedTutorToDisplay">
    <div class="row">
      <div class="col-md-12">

        <div class="row">
          <div class="col-md -12">
            <div class="float-start">
               <img v-if="selectedTutorToDisplay.imageUrl!=='' && selectedTutorToDisplay.imageUrl!== null" :src="globals.api_end_point+'/Tutors/GetImage/'+selectedTutorToDisplay.imageUrl" class="rounded float-left tutor-home-img" alt="...">
               <img v-if="selectedTutorToDisplay.imageUrl=='' || selectedTutorToDisplay.imageUrl==null" src="/assets/img/place-holder-profile-image.png" class="rounded float-left tutor-home-img" alt="...">
            </div>
            <div class="float-none">
              <table>
                <tr>
                  <td>
                    <br />
                    {{selectedTutorToDisplay.coutryName}}
                    <country-flag :country='selectedTutorToDisplay.coutryIso' size='small'/>
                  </td> 
                </tr>
                <tr>
                  <td>

                    <span v-for="language in selectedTutorToDisplay.languages" :key="language">
                      <div v-if="language.level == 3">
                        Advanced: 
                          <b>
                            {{language.lang.trim()}}
                          </b>
                      </div>
                    </span>
                    <br />

                    <span v-for="language in selectedTutorToDisplay.languages" :key="language">
                      <div v-if="language.level == 2">
                        Intermediate: 
                          <b>
                            {{language.lang.trim()}}
                          </b>
                      </div>
                    </span>
                    <br />

                    <span v-for="language in selectedTutorToDisplay.languages" :key="language">
                      <div v-if="language.level == 1">
                        Beginner :
                          <b>
                            {{language.lang.trim()}}
                          </b>
                      </div>
                    </span>
                    
                  </td>
                </tr>
              </table>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-md-12">
            <ul>
              <li v-for="course in selectedTutorToDisplay.courses" 
                  :key="course">{{course.trim().replace(" - " + selectedTutorToDisplay.email, "")}}
              </li>
            </ul>
          </div>
        </div>
        <div class="row">
          <div class="col-md-10">
             {{selectedTutorToDisplay.about}}
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {globals} from '@/assets/js/globals.js';
import CountryFlag from 'vue-country-flag-next';

export default {
  name: 'DisplayTutorInformation',
  components: {
    CountryFlag,
  },
  props: {
    selectedTutorToDisplay: Object,
    border: Boolean
  },
  data(){
    return {
      globals: globals,
    }
  },
}
</script>
