Feature: WorkflowRole

Scenario: Get All WorkflowRole records
  When I send "GET" all WorkflowRole request for "<Version>"
  Then I validate request <StatusCode>
  And I validate response body is not null
  
  Examples:
  | Version | StatusCode |
  | V1.0    | 200        |
  | V1.0    | 200        |