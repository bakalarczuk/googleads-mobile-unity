﻿// Copyright (C) 2020 Google LLC.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

/** This class is responsible for the countdown timer shown on a rewarded ad.
    After 5 seconds has elapsed, the close ad button will be set active and the user can then
    close the ad. **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    private float currentTime = 0f;
    private float startingTime = 5f;
    private Text[] countdownText;
    private Button[] buttons;

    public void Start()
    {
        countdownText = this.GetComponentsInChildren<Text>();
        buttons = this.GetComponentsInChildren<Button>();
        buttons[1].gameObject.SetActive(false);
        currentTime = startingTime;
    }

    // Update is called once per frame
    public void Update()
    {
        currentTime -= Time.unscaledDeltaTime;
        countdownText[1].text = Mathf.Round(currentTime).ToString() + " seconds remaining";

        if (currentTime <= 0)
        {
            currentTime = 0;
            countdownText[1].enabled = false;
            buttons[1].gameObject.SetActive(true);
        }
    }
}