﻿Module modLinkMapAddr

#Region "RST"
    Enum eRSTDevicNo
        ROBOT_STATUS_BIT_ARRAY1 = 0
        ROBOT_STATUS = 3
        RST_INTERFACE_LOG_COUNT = 4
        RST_TRACE_DATA_LOG_COUNT = 5
        CPC_TIMEOUT_COUNT = 6
        RST_ACTUAL_STATUS = 7

        CV1_LINK_STATUS = 10
        CV2_LINK_STATUS = 11
        EQ1_LINK_STATUS = 12
        EQ2_LINK_STATUS = 13
        EQ3_LINK_STATUS = 14

        RST_ALARM_WORD1 = 20
        RST_ALARM_WORD19 = 38

        RST_ARM_GX_EXIST = 68
        RST_BUFFER_GX_EXIST1 = 69
        RST_BUFFER_GX_EXIST2 = 70
        RST_BUFFER_GX_EXIST3 = 71
        RST_BUFFER_GX_EXIST4 = 72
        RST_BUFFER_GX_EXIST5 = 73
        RST_BUFFER_GX_EXIST6 = 74
        RST_BUFFER_GX_EXIST7 = 75

        RST_UPPER_ARM_GXINFO1 = 76
        RST_UPPER_ARM_GXINFO6 = 81
        RST_LOWER_ARM_GXINFO1 = 82
        RST_LOWER_ARM_GXINFO6 = 87
        RST_EQ1_WITH_GX_W1 = 88
        RST_EQ1_WITH_GX_W6 = 93
        RST_EQ2_WITH_GX_W1 = 94
        RST_EQ2_WITH_GX_W6 = 99
        RST_EQ3_WITH_GX_W1 = 100
        RST_EQ3_WITH_GX_W6 = 105

        RST_PROCESS_STRAT_QTY_P1 = 106
        RST_PROCESS_STRAT_QTY_P2 = 107
        RST_PROCESS_STRAT_QTY_P3 = 108
        RST_FLOW_OUT_QTY_P1 = 109
        RST_FLOW_OUT_QTY_P2 = 110
        RST_FLOW_OUT_QTY_P3 = 111
        RST_FLOW_IN_QTY_P1 = 112
        RST_FLOW_IN_QTY_P2 = 113
        RST_FLOW_IN_QTY_P3 = 114

        RST_STRAT_ARM = 115
        RST_STRAT_POSITION = 116
        RST_STRAT_SLOT = 117
        RST_STRAT_TARGET = 119
        RST_STRAT_CMD = 122
        RST_STRAT_ACTION = 123
        RST_STRAT_HANDSHAKE = 124

        RST_BUFFER_DISABLE1 = 125
        RST_BUFFER_DISABLE2 = 126
        RST_BUFFER_DISABLE3 = 127
        RST_BUFFER_DISABLE4 = 128
        RST_BUFFER_DISABLE5 = 129

        RST_COMMAND_ERR_ARM = 130
        RST_COMMAND_ERR_POSITION = 131
        RST_COMMAND_ERR_SLOT = 132
        RST_COMMAND_ERR_CASE = 133
        RST_COMMAND_ERR_TARGET = 134
        RST_COMMAND_ERR_JOB = 135
        RST_COMMAND_ERR_CMD = 137
        RST_COMMAND_ERR_ACTION = 138
        RST_COMMAND_ERR_HANDSHAKE = 139

        RST_GX_FLOW_IN1 = 140
        RST_GX_FLOW_IN2 = 141
        RST_GX_FLOW_IN3 = 142
        RST_GX_FLOW_IN4 = 143
        RST_GX_FLOW_IN5 = 144
        RST_GX_FLOW_IN6 = 145
        RST_GX_FLOW_IN7 = 146
        RST_GX_FLOW_IN8 = 147
        RST_GX_FLOW_IN9 = 148
        RST_GX_FLOW_IN10 = 149
        RST_GX_FLOW_IN11 = 150
        RST_GX_FLOW_IN12 = 151

        RST_GX_FLOW_OUT1 = 152
        RST_GX_FLOW_OUT2 = 153
        RST_GX_FLOW_OUT3 = 154
        RST_GX_FLOW_OUT4 = 155
        RST_GX_FLOW_OUT5 = 156
        RST_GX_FLOW_OUT6 = 157
        RST_GX_FLOW_OUT7 = 158
        RST_GX_FLOW_OUT8 = 159
        RST_GX_FLOW_OUT9 = 160
        RST_GX_FLOW_OUT10 = 161
        RST_GX_FLOW_OUT11 = 162
        RST_GX_FLOW_OUT12 = 163

        RST_167_STATUS_P1 = 164
        RST_167_GX_COUNT_P1 = 165
        RST_167_CST_GX_P1_1 = 166
        RST_167_CST_GX_P1_2 = 167
        RST_167_CST_GX_P1_3 = 168
        RST_167_CST_GX_P1_4 = 169

        RST_167_STATUS_P2 = 170
        RST_167_GX_COUNT_P2 = 171
        RST_167_CST_GX_P2_1 = 172
        RST_167_CST_GX_P2_2 = 173
        RST_167_CST_GX_P2_3 = 174
        RST_167_CST_GX_P2_4 = 175

        RST_167_STATUS_P3 = 176
        RST_167_GX_COUNT_P3 = 177
        RST_167_CST_GX_P3_1 = 178
        RST_167_CST_GX_P3_2 = 179
        RST_167_CST_GX_P3_3 = 180
        RST_167_CST_GX_P3_4 = 181

        RST_AXLE1 = 182
        RST_AXLE2 = 183
        RST_AXLE3 = 184
        RST_AXLE4 = 185
        RST_AXLE5 = 186
        RST_AXLE6 = 187
    End Enum

    Enum eRST_M_ADDR
        ROBOT_START = 9000
        ROBOT_ERROR_RESET = 9001
        TIME_CALIBRATION = 9002
        CPC_ALIVE = 9003
        ROBOT_PAUSE_REQUEST = 9004
        ROBOT_RESUME_REQUEST = 9005
        ROBOT_INTERFACE_CHECK = 9006

        RST_TOWER_R = 9007
        RST_TOWER_Y = 9008
        RST_TOWER_G = 9009

        RST_TOWER_R_BLINK = 9010
        RST_TOWER_Y_BLINK = 9011
        RST_TOWER_G_BLINK = 9012

        RST_BUZZER1 = 9013
        RST_BUZZER2 = 9014

        RST_BUF_GX_ERASE_REQ = 9015

        RST_UPPER_ARM_GX_ERASE = 9016
        RST_LOWER_ARM_GX_ERASE = 9017

        EQ1_IGNORE_TIMEOUT = 9018
        EQ2_IGNORE_TIMEOUT = 9019
        EQ3_IGNORE_TIMEOUT = 9020

        EQ1_MANUAL_SAMPLE_GX = 9021
        EQ2_MANUAL_SAMPLE_GX = 9022
        EQ3_MANUAL_SAMPLE_GX = 9023

        EQ1_TRANSFER_MODE = 9024
        EQ2_TRANSFER_MODE = 9025
        EQ3_TRANSFER_MODE = 9026

        RST_RUNNING_MODE = 9027

        RSTMODE_MANUAL = 9028
        RSTMODE_AUTO = 9029
        RSTMODE_ENGINEER = 9030
        RSTMODE_INIT = 9031
        RSTMODE_STOP = 9032
        RSTMODE_PM = 9033
        RSTMODE_START = 9034
        RSTDIO_TESTMODE = 9035
        RST_GLASS_MODIFY = 9036
        RST_BUFFER_DISABLE1 = 9200
        RST_BUFFER_DISABLE2 = 9225
        RST_BUFFER_DISABLE3 = 9250
        RST_STANDBY = 9037
        RST_RESET_FOLW_IN_OUT_BIT = 9038

        RST_GX_FLOW_IN_PORT1 = 9300
        RST_GX_FLOW_IN_PORT2 = 9360
        RST_GX_FLOW_IN_PORT3 = 9420

        RST_GX_FLOW_OUT_PORT1 = 9500
        RST_GX_FLOW_OUT_PORT2 = 9560
        RST_GX_FLOW_OUT_PORT3 = 9620
    End Enum

    Enum eRST_ZR_ADDR
        ROBOT_CMD_GO = 100
        ROBOT_CMD_ARM = 101
        ROBOT_CMD_ACTION = 102
        ROBOT_CMD_POSITION = 103
        ROBOT_CMD_SLOT_INFO = 104
        ROBOT_CMD_GLASS_TYPE = 105
        ROBOT_CMD_SPEED = 106

        TIME_YEAR = 107
        TIME_MONTH = 108
        TIME_DAY = 109
        TIME_HOUR = 110
        TIME_MIN = 111
        TIME_SEC = 112
        TIME_WEEK = 113

        RST_ERASE_BUF_POSITION = 114
        RST_ERASE_BUF_SLOT = 115

        RST_RUNNING_MODE = 116
        RST_REMOTE_STATUS = 117
        RST_ARM_MODE = 118
        RST_COLOR_REPAIR_RUN_MODE = 119

        TIME1_SAMPLE_GX_HH = 124
        TIME1_SAMPLE_GX_MM = 125

        TIME2_SAMPLE_GX_HH = 126
        TIME2_SAMPLE_GX_MM = 127

        TIME3_SAMPLE_GX_HH = 128
        TIME3_SAMPLE_GX_MM = 129

        TIME4_SAMPLE_GX_HH = 130
        TIME4_SAMPLE_GX_MM = 131

        SAMPLE_GX_EQ1_DAY = 132
        SAMPLE_GX_EQ2_DAY = 133

        RST_TRACEDATA_LOG_COUNT = 60000
        RST_RESET_INTERFACE_LOG_COUNT = 59000
        RST_TIMEOUT_COUNT = 60500
    End Enum
#End Region


#Region "EQ"
    Enum eEQDevicNo
        EVENT_WORD1 = 200
        EVENT_WORD2 = 201

        EQ1_STATUS = 203
        EQ1_STATUS_REPORT = 204

        EQ1_GX_ERASE_ID1 = 205
        EQ1_GX_ERASE_ID2 = 206
        EQ1_GX_ERASE_ID3 = 207
        EQ1_GX_ERASE_ID4 = 208
        EQ1_GX_ERASE_ID5 = 209
        EQ1_GX_ERASE_ID6 = 210

        EQ1_RECIPE_CHECK_RESUlT = 213
        EQ1_EPPID_MODIFIED_REPORT1 = 214
        EQ1_EPPID_MODIFIED_REPORT2 = 215
        EQ1_MODIFY_TYPE = 216
        EQ1_SAMPLE_GLASS_FLAG = 217
        EQ1_SLOT_INFO = 218
        EQ1_PROCESS_RESULT = 219
        EQ1_PSH_GROUP = 220

        EQ1_CHIP_GRADE1 = 222
        EQ1_CHIP_GRADE2 = 223
        EQ1_CHIP_GRADE3 = 224
        EQ1_CHIP_GRADE4 = 225
        EQ1_CHIP_GRADE5 = 226
        EQ1_CHIP_GRADE6 = 227
        EQ1_CHIP_GRADE7 = 228
        EQ1_CHIP_GRADE8 = 229
        EQ1_CHIP_GRADE9 = 230

        EQ1_GX_ID1 = 233
        EQ1_GX_ID2 = 234
        EQ1_GX_ID3 = 235
        EQ1_GX_ID4 = 236
        EQ1_GX_ID5 = 237
        EQ1_GX_ID6 = 238

        EQ1_ALARM_WORD1 = 249
        EQ1_ALARM_WORD32 = 280

        EQ2_STATUS = 281
        EQ2_STATUS_REPORT = 282

        EQ2_GX_ERASE_ID1 = 283
        EQ2_GX_ERASE_ID2 = 284
        EQ2_GX_ERASE_ID3 = 285
        EQ2_GX_ERASE_ID4 = 286
        EQ2_GX_ERASE_ID5 = 287
        EQ2_GX_ERASE_ID6 = 288

        EQ2_RECIPE_CHECK_RESUlT = 291
        EQ2_EPPID_MODIFIED_REPORT1 = 292
        EQ2_EPPID_MODIFIED_REPORT2 = 293
        EQ2_MODIFY_TYPE = 294
        EQ2_SAMPLE_GLASS_FLAG = 295
        EQ2_SLOT_INFO = 296
        EQ2_PROCESS_RESULT = 297
        EQ2_PSH_GROUP = 298

        EQ2_CHIP_GRADE1 = 300
        EQ2_CHIP_GRADE2 = 301
        EQ2_CHIP_GRADE3 = 302
        EQ2_CHIP_GRADE4 = 303
        EQ2_CHIP_GRADE5 = 304
        EQ2_CHIP_GRADE6 = 305
        EQ2_CHIP_GRADE7 = 306
        EQ2_CHIP_GRADE8 = 307
        EQ2_CHIP_GRADE9 = 308

        EQ2_GX_ID1 = 311
        EQ2_GX_ID2 = 312
        EQ2_GX_ID3 = 313
        EQ2_GX_ID4 = 314
        EQ2_GX_ID5 = 315
        EQ2_GX_ID6 = 316

        EQ2_ALARM_WORD1 = 327
        EQ2_ALARM_WORD32 = 358

        EQ3_STATUS = 359
        EQ3_STATUS_REPORT = 360

        EQ3_GX_ERASE_ID1 = 361
        EQ3_GX_ERASE_ID2 = 362
        EQ3_GX_ERASE_ID3 = 363
        EQ3_GX_ERASE_ID4 = 364
        EQ3_GX_ERASE_ID5 = 365
        EQ3_GX_ERASE_ID6 = 366

        EQ3_RECIPE_CHECK_RESUlT = 369
        EQ3_EPPID_MODIFIED_REPORT1 = 370
        EQ3_EPPID_MODIFIED_REPORT2 = 371
        EQ3_MODIFY_TYPE = 372
        EQ3_SAMPLE_GLASS_FLAG = 373
        EQ3_SLOT_INFO = 374
        EQ3_PROCESS_RESULT = 375
        EQ3_PSH_GROUP = 376

        EQ3_CHIP_GRADE1 = 378
        EQ3_CHIP_GRADE2 = 379
        EQ3_CHIP_GRADE3 = 380
        EQ3_CHIP_GRADE4 = 381
        EQ3_CHIP_GRADE5 = 382
        EQ3_CHIP_GRADE6 = 383
        EQ3_CHIP_GRADE7 = 384
        EQ3_CHIP_GRADE8 = 385
        EQ3_CHIP_GRADE9 = 386

        EQ3_GX_ID1 = 389
        EQ3_GX_ID2 = 390
        EQ3_GX_ID3 = 391
        EQ3_GX_ID4 = 392
        EQ3_GX_ID5 = 393
        EQ3_GX_ID6 = 394

        EQ3_ALARM_WORD1 = 405
        EQ3_ALARM_WORD32 = 436

        EQ_INFO_REPORT_AMPLE_GX_FLAG = 437
        EQ_INFO_REPORT_PRODUCT_CATEGORY = 438
        EQ_INFO_REPORT_SLOT_NO = 439

        EQ_INFO_REPORT_GX_ID_WORD1 = 440
        EQ_INFO_REPORT_GX_ID_WORD6 = 445
        EQ_INFO_REPORT_EPPID1 = 446
        EQ_INFO_REPORT_EPPID2 = 447

        EQ_INFO_REPORT_MESID_WORD1 = 449
        EQ_INFO_REPORT_MESID_WORD4 = 452

        EQ_INFO_REPORT_PRODUCT_CODE_W1 = 453
        EQ_INFO_REPORT_PRODUCT_CODE_W13 = 465

        EQ_INFO_REPORT_CURR_PPID_W1 = 469
        EQ_INFO_REPORT_CURR_PPID_W16 = 484

        EQ_INFO_REPORT_POPERID_W1 = 485
        EQ_INFO_REPORT_POPERID_W13 = 497

        EQ_INFO_REPORT_PLINEID_W1 = 501
        EQ_INFO_REPORT_PLINEID_W4 = 504

        EQ_INFO_REPORT_PTOOLID_W1 = 509
        EQ_INFO_REPORT_PTOOLID_W4 = 512

        EQ_INFO_REPORT_CST_ID_W1 = 517
        EQ_INFO_REPORT_CST_ID_W3 = 519

        EQ_INFO_REPORT_OP_ID_W1 = 521
        EQ_INFO_REPORT_OP_ID_W13 = 533

        EQ_INFO_REPORT_GX_GRADE = 535
        EQ_INFO_REPORT_DMQC_GRADE = 536
        EQ_INFO_REPORT_GX_SCRAP_FLAG = 537
        EQ_INFO_REPORT_AIO_FUN_MODE = 538
        EQ_INFO_REPORT_MPA_FLAG = 541

        EQ1_TOOL_ID_W1 = 549
        EQ1_TOOL_ID_W6 = 552
        EQ2_TOOL_ID_W1 = 553
        EQ2_TOOL_ID_W6 = 556
        EQ3_TOOL_ID_W1 = 557
        EQ3_TOOL_ID_W6 = 560

    End Enum

    Enum eEQ_M_ADDR
        EQ1_RECIPE_CHECK_REQUEST = 9150
        EQ1_TRANSFER_RESET = 9154
        EQ1_GX_ERASE_REPORT_ACK = 9158
        EQ1_GX_DATA_RESULT_ACK = 9162
        EQ1_RECIPE_MODIFY_REPORT_ACK = 9166

        'For CV Spec Addr
        EQ1_RST_LINK_REQUEST = 9082

        'Delete EQ Gx Data 
        EQ1_DEL_GX_DATA = 9170
        EQ2_DEL_GX_DATA = 9171
        EQ3_DEL_GX_DATA = 9172

        EQ1_RECIPE_QUERY_REQ = 9174
        EQ2_RECIPE_QUERY_REQ = 9175
        EQ3_RECIPE_QUERY_REQ = 9176
    End Enum

#End Region

#Region "CV"
    Enum eCVDevicNo
        EVENT_WORD1 = 0
        EVENT_WORD2 = 1
        EVENT_WORD3 = 2
        EVENT_WORD4 = 3

        PORT1_ACTION_STATUS = 5
        PORT1_CSTID_WORD_1 = 6
        PORT1_CSTID_WORD_2 = 7
        PORT1_CSTID_WORD_3 = 8

        PORT2_ACTION_STATUS = 9
        PORT2_CSTID_WORD_1 = 10
        PORT2_CSTID_WORD_2 = 11
        PORT2_CSTID_WORD_3 = 12

        PORT3_ACTION_STATUS = 13
        PORT3_CSTID_WORD_1 = 14
        PORT3_CSTID_WORD_2 = 15
        PORT3_CSTID_WORD_3 = 16

        PORT4_ACTION_STATUS = 17
        PORT4_CSTID_WORD_1 = 18
        PORT4_CSTID_WORD_2 = 19
        PORT4_CSTID_WORD_3 = 20

        CV_OPMODE = 24
        CV_STATUS = 25
        GXQTYINCST_1_2 = 26
        GXQTYINCST_3_4 = 27
        GXQTYINCST_5 = 28
        PORTMODE = 29
        UNLOAD_PORT_TYPE_1_4 = 30
        UNLOAD_PORT_TYPE_5 = 31
        USEVCR_PEXIST_PDISABLE = 32
        PORTSUBSTATUS_HANDOFF = 33

        GLASS_JUDGMENT_1 = 34
        PS_H_GRADE_1 = 35
        PRODUCT_CODE_P1_1 = 36
        PRODUCT_CODE_P1_2 = 37
        PRODUCT_CODE_P1_3 = 38
        PRODUCT_CODE_P1_4 = 39
        PRODUCT_CODE_P1_5 = 40
        PRODUCT_CODE_P1_6 = 41
        PRODUCT_CODE_P1_7 = 42
        PRODUCT_CODE_P1_8 = 43
        PRODUCT_CODE_P1_9 = 44
        PRODUCT_CODE_P1_10 = 45
        PRODUCT_CODE_P1_11 = 46
        PRODUCT_CODE_P1_12 = 47
        PRODUCT_CODE_P1_13 = 48

        GXID_P1_1 = 49
        GXID_P1_2 = 50
        GXID_P1_3 = 51
        GXID_P1_4 = 52
        GXID_P1_5 = 53
        GXID_P1_6 = 54
        OPID_1 = 55

        GLASS_JUDGMENT_2 = 56
        PS_H_GRADE_2 = 57
        PRODUCT_CODE_P2_1 = 58
        PRODUCT_CODE_P2_2 = 59
        PRODUCT_CODE_P2_3 = 60
        PRODUCT_CODE_P2_4 = 61
        PRODUCT_CODE_P2_5 = 62
        PRODUCT_CODE_P2_6 = 63
        PRODUCT_CODE_P2_7 = 64
        PRODUCT_CODE_P2_8 = 65
        PRODUCT_CODE_P2_9 = 66
        PRODUCT_CODE_P2_10 = 67
        PRODUCT_CODE_P2_11 = 68
        PRODUCT_CODE_P2_12 = 69
        PRODUCT_CODE_P2_13 = 70

        GXID_P2_1 = 71
        GXID_P2_2 = 72
        GXID_P2_3 = 73
        GXID_P2_4 = 74
        GXID_P2_5 = 75
        GXID_P2_6 = 76
        OPID_2 = 77

        GLASS_JUDGMENT_3 = 78
        PS_H_GRADE_3 = 79
        PRODUCT_CODE_P3_1 = 80
        PRODUCT_CODE_P3_2 = 81
        PRODUCT_CODE_P3_3 = 82
        PRODUCT_CODE_P3_4 = 83
        PRODUCT_CODE_P3_5 = 84
        PRODUCT_CODE_P3_6 = 85
        PRODUCT_CODE_P3_7 = 86
        PRODUCT_CODE_P3_8 = 87
        PRODUCT_CODE_P3_9 = 88
        PRODUCT_CODE_P3_10 = 89
        PRODUCT_CODE_P3_11 = 90
        PRODUCT_CODE_P3_12 = 91
        PRODUCT_CODE_P3_13 = 92
        GXID_P3_1 = 93
        GXID_P3_2 = 94
        GXID_P3_3 = 95
        GXID_P3_4 = 96
        GXID_P3_5 = 97
        GXID_P3_6 = 98
        OPID_3 = 99

        GLASS_JUDGMENT_4 = 100
        PS_H_GRADE_4 = 101
        PRODUCT_CODE_P4_1 = 102
        PRODUCT_CODE_P4_2 = 103
        PRODUCT_CODE_P4_3 = 104
        PRODUCT_CODE_P4_4 = 105
        PRODUCT_CODE_P4_5 = 106
        PRODUCT_CODE_P4_6 = 107
        PRODUCT_CODE_P4_7 = 108
        PRODUCT_CODE_P4_8 = 109
        PRODUCT_CODE_P4_9 = 110
        PRODUCT_CODE_P4_10 = 111
        PRODUCT_CODE_P4_11 = 112
        PRODUCT_CODE_P4_12 = 113
        PRODUCT_CODE_P4_13 = 114

        GXID_P4_1 = 115
        GXID_P4_2 = 116
        GXID_P4_3 = 117
        GXID_P4_4 = 118
        GXID_P4_5 = 119
        GXID_P4_6 = 120
        OPID_4 = 121

        UNLOAD_STATUS_TOTAL_GX_QTY_1 = 122
        UNLOAD_STATUS_TOTAL_GX_QTY_2 = 123
        UNLOAD_STATUS_TOTAL_GX_QTY_3 = 124
        UNLOAD_STATUS_TOTAL_GX_QTY_4 = 125

        GX_ABNORMAL_CASE = 126
        GX_ABNORMAL_SGID1 = 127
        GX_ABNORMAL_SGID2 = 128
        GX_ABNORMAL_SGID3 = 129
        GX_ABNORMAL_SGID4 = 130
        GX_ABNORMAL_SGID5 = 131
        GX_ABNORMAL_SGID6 = 132
        GX_ABNORMAL_VCRGXID1 = 133
        GX_ABNORMAL_VCRGXID2 = 134
        GX_ABNORMAL_VCRGXID3 = 135
        GX_ABNORMAL_VCRGXID4 = 136
        GX_ABNORMAL_VCRGXID5 = 137
        GX_ABNORMAL_VCRGXID6 = 138
        GX_ABNORMAL_POSITION = 139
        GLASS_UNMATCH_REPORT = 140

        PORT_CHANG_REPORT_PORTNO1 = 141
        PORT_CHANG_REPORT_RESULT1 = 142
        PT_CHG_PORTMODE1 = 143
        PT_CHG_PORTTYPE1 = 144

        PORT_CHANG_REPORT_PORTNO2 = 145
        PORT_CHANG_REPORT_RESULT2 = 146
        PT_CHG_PORTMODE2 = 147
        PT_CHG_PORTTYPE2 = 148

        PORT_CHANG_REPORT_PORTNO3 = 149
        PORT_CHANG_REPORT_RESULT3 = 150
        PT_CHG_PORTMODE3 = 151
        PT_CHG_PORTTYPE3 = 152

        DUMMY_CANCEL_RESULT = 158
        CV_CST_REMOVE_REPORT = 159

        CST_PRESENT_PORT_NO = 160

        PORT1_CANCEL_REPORT = 161
        PORT2_CANCEL_REPORT = 162
        PORT3_CANCEL_REPORT = 162

        GX_DATA_REQ_GXID_W1 = 166
        GX_DATA_REQ_GXID_W6 = 171
        GX_DATA_REQ_PRODUCT_W1 = 172
        GX_DATA_REQ_PRODUCT_W13 = 184
        GX_DATA_REQ_PSH_GRADE = 185
        GX_DATA_REQ_GX_JUDGMENT = 186
        GX_DATA_REQ_VCR_READ_POSITION = 187

        GX_F_IN_PORT_IDX = 190
        GX_F_IN_PRODUCT_CODE1 = 191
        GX_F_IN_PRODUCT_CODE2 = 192
        GX_F_IN_PRODUCT_CODE3 = 193
        GX_F_IN_PRODUCT_CODE4 = 194
        GX_F_IN_PRODUCT_CODE5 = 195
        GX_F_IN_PRODUCT_CODE6 = 196
        GX_F_IN_PRODUCT_CODE7 = 197
        GX_F_IN_PRODUCT_CODE8 = 198
        GX_F_IN_PRODUCT_CODE9 = 199
        GX_F_IN_PRODUCT_CODE10 = 200
        GX_F_IN_PRODUCT_CODE11 = 201
        GX_F_IN_PRODUCT_CODE12 = 202
        GX_F_IN_PRODUCT_CODE13 = 203
        GX_F_IN_GX_ID1 = 204
        GX_F_IN_GX_ID2 = 205
        GX_F_IN_GX_ID3 = 206
        GX_F_IN_GX_ID4 = 207
        GX_F_IN_GX_ID5 = 208
        GX_F_IN_GX_ID6 = 209
        GX_F_IN_SLOT_NUMBER = 210

        GX_F_OUT_PORT_IDX_P1 = 211
        GX_F_OUT_PRODUCT_CODE1_P1 = 212
        GX_F_OUT_PRODUCT_CODE13_P1 = 224
        GX_F_OUT_GX_ID1_P1 = 225
        GX_F_OUT_GX_ID2_P1 = 230
        GX_F_OUT_SLOT_NUMBER_P1 = 234

        GX_F_OUT_PORT_IDX_P2 = 235
        GX_F_OUT_PRODUCT_CODE1_P2 = 236
        GX_F_OUT_PRODUCT_CODE13_P2 = 248
        GX_F_OUT_GX_ID1_P2 = 249
        GX_F_OUT_GX_ID2_P2 = 254
        GX_F_OUT_SLOT_NUMBER_P2 = 258

        GX_F_OUT_PORT_IDX_P3 = 259
        GX_F_OUT_PRODUCT_CODE1_P3 = 260
        GX_F_OUT_PRODUCT_CODE13_P3 = 272
        GX_F_OUT_GX_ID1_P3 = 273
        GX_F_OUT_GX_ID2_P3 = 278
        GX_F_OUT_SLOT_NUMBER_P3 = 282

        GX_EXIST_ON_CV_POSITION1 = 290
        GX_EXIST_ON_CV_POSITION2 = 291
        GX_EXIST_ON_CV_POSITION3 = 292
        GX_EXIST_ON_CV_POSITION4 = 293
        GX_EXIST_ON_CV_POSITION5 = 294

        CV_TOOL_ID_W1 = 295
        CV_TOOL_ID_W6 = 300

        CV_ALARM_WORD1 = 301
        CV_ALARM_WORD32 = 332

        CST_PPORT1_PRODUCT_CODE1 = 333
        CST_PPORT1_PRODUCT_CODE13 = 345
        CST_PPORT2_PRODUCT_CODE1 = 346
        CST_PPORT2_PRODUCT_CODE13 = 358
        CST_PPORT3_PRODUCT_CODE1 = 359
        CST_PPORT3_PRODUCT_CODE13 = 371
        CST_PPORT4_PRODUCT_CODE1 = 372
        CST_PPORT4_PRODUCT_CODE13 = 384

        CV_POSITION1_GXID_W1 = 385
        CV_POSITION1_GXID_W6 = 390
        CV_POSITION2_GXID_W1 = 391
        CV_POSITION2_GXID_W6 = 396
        CV_POSITION3_GXID_W1 = 397
        CV_POSITION3_GXID_W6 = 402
        CV_POSITION4_GXID_W1 = 403
        CV_POSITION4_GXID_W6 = 408
        CV_POSITION5_GXID_W1 = 409
        CV_POSITION5_GXID_W6 = 414
        CV_POSITION6_GXID_W1 = 415
        CV_POSITION6_GXID_W6 = 420

        EQ1_EPPID_QUERY_RESULT = 421
        EQ1_PARAMETER = 426
        EQ2_EPPID_QUERY_RESULT = 436
        EQ2_PARAMETER = 441
        EQ3_EPPID_QUERY_RESULT = 451
        EQ3_PARAMETER = 456
    End Enum

    Enum eCV_M_ADDR
        TRANSFER_RESET_REQUEST = 9050
        GX_ABNORMAL_REPORT_ACT = 9051
        GX_INFO_UNMATCH_REPORT_ACK = 9052
        CST_PROCESS_CMD_REQ = 9054
        S765_DATA_DOWNLOAD_REQ_P1 = 9055
        S765_DATA_DOWNLOAD_REQ_P2 = 9056
        S765_DATA_DOWNLOAD_REQ_P3 = 9057
        GX_FLOWIN_ACK = 9058


        S167_ACK_P1 = 9060
        S167_ACK_P2 = 9061
        S167_ACK_P3 = 9062

        DUMMY_CANCEL_REQ_P1 = 9065
        DUMMY_CANCEL_REQ_P2 = 9066
        DUMMY_CANCEL_REQ_P3 = 9067

        PORT_PAUSE_REQ_P1 = 9070
        PORT_PAUSE_REQ_P2 = 9071
        PORT_PAUSE_REQ_P3 = 9072

        PORT_RESUME_RQE_P1 = 9075
        PORT_RESUME_RQE_P2 = 9076
        PORT_RESUME_RQE_P3 = 9077

        RST_LINK_REQUEST_CV1 = 9080
        RST_LINK_REQUEST_CV2 = 9081


        CASSETTE_UNLOAD_REQUEST_P1 = 9085
        CASSETTE_UNLOAD_REQUEST_P2 = 9086
        CASSETTE_UNLOAD_REQUEST_P3 = 9087

        PORT_CHANGE_REQUEST = 9090
        GX_DATA_REQUEST_REPORT_ACK = 9091

        PORT1_CHANGE_REPORT_ACK = 9092
        PORT2_CHANGE_REPORT_ACK = 9093
        PORT3_CHANGE_REPORT_ACK = 9094

        GX_FLOWOUT_ACK_P1 = 9095
        GX_FLOWOUT_ACK_P2 = 9096
        GX_FLOWOUT_ACK_P3 = 9097

    End Enum

    Enum eCV_ZR_ADDR
        PORT_NUMBER = 167
        PROCESS_COMMAND = 168
        CST_SLOT_INFO = 169
        PROCESS_GX_QUANTITY = 173
        PROCESS_COMMAND_CST_ID = 174

        PORT_CHANGE_PORTNO = 150
        PORT_CHANGE_PRODUCTCODE = 151
        PORT_CHANGE_PORTMODE = 164
        PORT_CHANGE_PORTTYPE = 165
    End Enum

#End Region

#Region "PLC"
    Enum ePLC_ZR_ADDR
        BUF_PORT1_SLOT_STATUS_START_ADDR = 1600
        BUF_PORT2_SLOT_STATUS_START_ADDR = 1625
        BUF_PORT3_SLOT_STATUS_START_ADDR = 1650
        BUF_PORT4_SLOT_STATUS_START_ADDR = 1675

        BUF_PORT1_TARGET_BIT_START_ADDR = 1700
        BUF_PORT2_TARGET_BIT_START_ADDR = 1725
        BUF_PORT3_TARGET_BIT_START_ADDR = 1750
        BUF_PORT4_TARGET_BIT_START_ADDR = 1775

        PORT1_LINEID = 28000
        PORT1_GX_ID_SLOT1 = 28080

        S167_PORT1_LINEID = 40000
        S167_PORT1_GX_ID_SLOT1 = 40050
    End Enum


    Enum eBufferPortDevicNo
        GX_DATA_REF = 0
        SAMPLE_GXFLAGE = 1
        PRODUCT_CATEGORY = 2
        SLOT_INFO = 3
        GXID_W1 = 4
        GXID_W6 = 9
        EPPID_W1 = 10
        EPPID_W2 = 11
        MESID_W1 = 13
        MESID_W4 = 16

        PRODUCT_CODE_W1 = 17
        PRODUCT_CODE_W13 = 29
        CURRENT_RECIPE_W1 = 33
        CURRENT_RECIPE_W16 = 48
        POPERID_W1 = 49
        POPERID_W13 = 61
        PLINEID_W1 = 65
        PLINEID_W4 = 68
        PTOOLID_W1 = 73
        PTOOLID_W4 = 76
        CSTID_W1 = 81
        CSTID_W3 = 83
        OPERATIONID_W1 = 85
        OPERATIONID_W13 = 97
        GLASS_GRADE = 99
        DMQC_GRADE = 100
        GX_SCRAP_FLAG = 101
        AOI_FUNCTION_MODE = 102

        ALNFLAG = 105
        FI_INSPECTION_FLAG = 109

        RDGRADE = 113
        DGRADE = 114
        GGRADE = 115
        PSH_GRADE_W1 = 116
        PSH_GRADE_W2 = 117
        PTOOLID_IDX = 118
        DMQC_TOOLID_W1 = 119
        DMQC_TOOLID_W4 = 122
        CHIP_GRADE_W1 = 123
        CHIP_GRADE_W9 = 131
        FIRMFLAG_SCRPFLAG_RWKFLAG = 132
        REPAIRREVIEWFLAG = 133

        RST_SPEED = 139
        PORT_NO = 140

        REPAIR_INK_FLAG = 141
        PROCESS_FLAG = 142
        FIFCF_FLAG = 144

        EQ1PPID_W1 = 145
        EQ1PPID_W2 = 146
        EQ2PPID_W1 = 147
        EQ2PPID_W2 = 148

        TARGET_POSITION = 149

        EQ1_START_TIME1 = 150
        EQ1_START_TIME2 = 151
        EQ1_START_TIME3 = 152

        EQ2_START_TIME1 = 153
        EQ2_START_TIME2 = 154
        EQ2_START_TIME3 = 155

        EQ3_START_TIME1 = 156
        EQ3_START_TIME2 = 157
        EQ3_START_TIME3 = 158

        EQ1_END_TIME1 = 159
        EQ1_END_TIME2 = 160
        EQ1_END_TIME3 = 161

        EQ2_END_TIME1 = 162
        EQ2_END_TIME2 = 163
        EQ2_END_TIME3 = 164

        EQ3_END_TIME1 = 165
        EQ3_END_TIME2 = 166
        EQ3_END_TIME3 = 167

    End Enum

    Enum ePLC_S765_DeviceNo
        LINEID_W1 = 0
        LINEID_W4 = 3
        TOOLID_W1 = 4
        TOOLID_W4 = 7
        CASSETTEID_W1 = 8
        CASSETTEID_W3 = 10
        PRODUCT_CODE_W1 = 11
        PRODUCT_CODE_W13 = 23
        PRODUCT_CATEGORY1 = 24
        PRODUCT_CATEGORY2 = 25
        MEASUREMENT_ID_W1 = 26
        MEASUREMENT_ID_W4 = 29
        OP_ID_W1 = 30
        OP_ID_W13 = 42
        EPPID_EQ1_W1 = 43
        EPPID_EQ1_W2 = 44
        EPPID_EQ2_W1 = 47
        EPPID_EQ2_W2 = 48
        TARGET_POSITION = 51
        AOI_FUNCTION = 52
        RUNNING_MODE = 53
        ROBOT_SPEED = 54
        GLASS_TYPE = 55
        VCR_POSITION = 56
        CURRENT_RECIPE_W1 = 57
        CURRENT_RECIPE_W16 = 72
    End Enum

    Enum ePLC_DeviceNo
        '---------765 Lot Addr-------------
        LINEID = 0
        TOOLID = 4
        CASSETTEID = 8
        PRODUCT_CODE = 11
        PRODUCT_CATEGORY1 = 24
        PRODUCT_CATEGORY2 = 25
        MEASUREMENT_ID = 26
        OP_ID = 30
        EPPID_EQ1 = 43
        EPPID_EQ2 = 47
        TARGET_POSITION = 51
        AOI_FUNCTION = 52
        RUNNING_MODE = 53
        ROBOT_SPEED = 54
        GLASS_TYPE = 55
        VCR_POSITION = 56
        CURRENT_RECIPE = 57

        '---------765 Slot Addr-------------
        GLASS_ID_BY_SLOT = 0
        POPERID = 6
        PLINEID = 19
        PTOOLID = 23
        DMQCTOOL_ID = 27
        GGRADE = 31
        DGRADE = 32
        PSH_GROUP = 33
        RWKFLAG = 35
        SCRPFlAG = 36
        FIRMFLAG = 37
        FIFCFLAG = 38
        PROCESS_FLAG = 39
    End Enum


    Enum ePLC_S167_DeviceNo
        CASSETTE_ID_WORD1 = 0
        CASSETTE_ID_WORD3 = 2
        CASSETTE_STATUS = 3
        OPERATION_ID_W1 = 4
        OPERATION_ID_W13 = 16
        PORT_TYPE_MODE = 17
        CST_UNLOAD_STATUS = 18
        TOTAL_QTY_IN_CST = 19
        '-----------------------
        GLASS_ID_SLOT_WORD1 = 0
        GLASS_ID_SLOT_WORD6 = 5
        RDRAGE_DGRADE_GGRADE = 6
        PSH_GROUP_WORD1 = 7
        PSH_GROUP_WORD2 = 8
        PTOOLID_WORD1 = 9
        PTOOLID_WORD4 = 12
        DMQC_TOOL_ID_WORD1 = 13
        DMQC_TOOL_ID_WORD4 = 16
        CHIP_GRADE_WORD1 = 17
        CHIP_GRADE_WORD9 = 25
        FIRMFLAG_SCRPFLAG_RWKFLAG = 26


        PRODUCT_CATEGORY = 27
        CURR_RECIPEIDW1 = 28
        CURR_RECIPEIDW16 = 43

        EQ1_TAPE_EPPIDW1 = 44
        EQ1_TAPE_EPPIDW2 = 45

        EQ2_INK_EPPIDW1 = 46
        EQ2_INK_EPPIDW2 = 47

        EQ1_START_TIME_1 = 48
        EQ1_START_TIME_2 = 49
        EQ1_START_TIME_3 = 50

        EQ2_START_TIME_1 = 51
        EQ2_START_TIME_2 = 52
        EQ2_START_TIME_3 = 53

        EQ3_START_TIME_1 = 54
        EQ3_START_TIME_2 = 55
        EQ3_START_TIME_3 = 56

        EQ1_END_TIME_1 = 57
        EQ1_END_TIME_2 = 58
        EQ1_END_TIME_3 = 59

        EQ2_END_TIME_1 = 60
        EQ2_END_TIME_2 = 61
        EQ2_END_TIME_3 = 62

        EQ3_END_TIME_1 = 63
        EQ3_END_TIME_2 = 64
        EQ3_END_TIME_3 = 65

    End Enum

#End Region

End Module
