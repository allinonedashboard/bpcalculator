import { check, sleep } from "k6";
import http from "k6/http";


export let options = {

  stages: [
    { duration: "1m", target: 20 },            // 1 new vu every 3 seconds
    { duration: "1m", target: 20 },
    { duration: "1m", target: 0 }             // 1 less vu every 3 seconds
  ],

 	thresholds: {
    "http_req_duration": ["p(95) < 200"]
  },
  discardResponseBodies: false,
  ext: {
    loadimpact: {
      distribution: {
        loadZoneLabel1: { loadZone: "amazon:ie:dublin", percent: 100 },
      }
    }
  }
};


function getRandomInt(min, max) {
  return Math.floor(Math.random() * (max - min + 1) + min);
}


export default function() {
  let res = http.get("https://bpcheck.azurewebsites.net", {"responseType": "text"});
  check(res, {
    "is status 200": (r) => r.status === 200
  });
  res = res.submitForm({
    fields: { Bp_Systolic: getRandomInt(70, 100).toString(), Bp_Diastolic: getRandomInt(40, 60).toString()}
  });

  check(res, {
    "is status 200": (r) => r.status === 200
  });

  // "think" for 3 seconds
  sleep(3);
}

// to run on Docker:
// docker pull loadimpact/k6
// docker run -i loadimpact/k6 run - <perf2.js
